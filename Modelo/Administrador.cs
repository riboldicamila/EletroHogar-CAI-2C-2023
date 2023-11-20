namespace Modelo
{
    public class Administrador : Usuario
    {
        public Administrador(UsuarioWS usuarioWS) : base(usuarioWS)
        {
        }

        //public Administrador(string nombre, string apellido, string username) : base(nombre, apellido, username)
        //{
        //    //el base llama al constructor de la abstracta
        //}

        //Quedo en sin uso. Se había implementado herencia en un momento pero antes del ws. 

    }


}









