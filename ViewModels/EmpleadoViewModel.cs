using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Input;

using Microsoft.EntityFrameworkCore;
using DavidAppCrud.DataAcess;
using DavidAppCrud.DTOs;
using DavidAppCrud.Utilidades;
using DavidAppCrud.Modelos;

namespace DavidAppCrud.ViewModels
{
    public partial class EmpleadoViewModel : ObservableObject, IQueryAttributable
    {
        private readonly EmpleadoDbContext _dbContext;
        [ObservableProperty]
        private EmpleadoDTO empleadoDto = new EmpleadoDTO();

        [ObservableProperty]
        private String tituloPagina;

        private int idEmpleado;
        [ObservableProperty]
        private bool loadingEsVisible = false;

        public EmpleadoViewModel(EmpleadoDbContext context)
        {
            _dbContext = context;
            EmpleadoDto.FechaContrato = DateTime.Now;
        }
        public async Task ApplyQueryAttributes(IDictionary<string, object> query)
        {
            var id = int.Parse(query["id"].ToString());
            idEmpleado = id;

            if (idEmpleado == 0)
            {
                TituloPagina = "Nuevo Empleado";
            }
            else
            {
                TituloPagina = "Editar Empleado";
                LoadingEsVisible = true;
                await Task.Run(async () =>
                {
                    var encontrado = await _dbContext.Empleados.FirstAsync(e => e.idEmpleado == idEmpleado);
                    EmpleadoDto.idEmpleado = encontrado.idEmpleado;
                    EmpleadoDto.NombreCompleto = encontrado.NombreCompleto;
                    EmpleadoDto.Correo = encontrado.Correo;
                    EmpleadoDto.Sueldo = encontrado.Sueldo;
                    EmpleadoDto.FechaContrato = encontrado.FechaContrato;


                    MainThread.BeginInvokeOnMainThread(() => { LoadingEsVisible = false; });


                });
            }

            [RelayCommand]
            async Task Guardar()
            {
                LoadingEsVisible = true;
                EmpleadoMensaje mensaje = new EmpleadoMensaje();

                await Task.Run(async () => { 
                
                    if(idEmpleado == 0)
                    {
                        var tbEmpleado = new Empleado
                        {
                            NombreCompleto = EmpleadoDto.NombreCompleto,
                            Correo = EmpleadoDto.Correo,
                            Sueldo = EmpleadoDto.Sueldo,
                            FechaContrato = EmpleadoDto.FechaContrato,
                        };
                        _dbContext.Empleados.Add(tbEmpleado);
                        await _dbContext.SaveChangesAsync();

                        EmpleadoDto.idEmpleado = tbEmpleado.idEmpleado;
                        mensaje = new EmpleadoMensaje()
                        {
                            EsCrear = true,
                            EmpleadoDto = EmpleadoDto
                        };
                    }
                    else
                    {
                        var encontrado = await _dbContext.Empleados.FirstAsync(e => e.idEmpleado == idEmpleado);
                        encontrado.NombreCompleto = EmpleadoDto.NombreCompleto;
                        encontrado.Correo = EmpleadoDto.Correo;
                        encontrado.Sueldo = EmpleadoDto.Sueldo;
                        encontrado.FechaContrato = EmpleadoDto.FechaContrato;
                        await _dbContext.SaveChangesAsync();

                        mensaje = new EmpleadoMensaje()
                        {
                            EsCrear = true,
                            EmpleadoDto = EmpleadoDto
                        };
                    }
                    MainThread.BeginInvokeOnMainThread(async () =>
                    {
                        LoadingEsVisible = false;
                        WeakReferenceMessenger.Default.Send(new EmpleadoMensajeria(mensaje));
                        await Shell.Current.Navigation.PopAsync();
                    });
                });
            }
        }

        void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
        {
            throw new NotImplementedException();
        }
    }
}
