using CommunityToolkit.Mvvm.Messaging.Messages;

namespace DavidAppCrud.Utilidades
{
    public class EmpleadoMensajeria : ValueChangedMessage<EmpleadoMensaje>
    {
        public EmpleadoMensaje(EmpleadoMensaje value):base(value)
        {

        }
    }
}
