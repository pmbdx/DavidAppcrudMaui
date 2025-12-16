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

        }
        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            throw new NotImplementedException();
        }
    }
}
