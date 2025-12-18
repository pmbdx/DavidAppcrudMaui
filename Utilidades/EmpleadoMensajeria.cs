using CommunityToolkit.Mvvm.Messaging.Messages;

namespace DavidAppCrud.Utilidades
{
    public class EmpleadoMensajeria : ValueChangedMessage<EmpleadoMensaje>
    {
        public EmpleadoMensajeria(EmpleadoMensaje value):base(value)
        {

        }
    }
}
