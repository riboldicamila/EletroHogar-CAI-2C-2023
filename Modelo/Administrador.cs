namespace Modelo
{
    public class Administrador : Usuario
    {
        public Administrador(UsuarioWS usuarioWS) : base(usuarioWS)
        {
        }

        public Administrador(string nombre, string apellido, string username) : base(nombre, apellido, username)
        {
            //el base llama al constructor de la abstracta
        }

    }


    //public class Producto
    //{
    //    public string Nombre { get; set; }
    //    public decimal Precio { get; set; }
    //    public int Stock { get; set; }
    //    public string Categoria { get; set; }


    //    //CONSTRUCTOR
    //    public Producto(string nombre, decimal precio, int stock, string categoria)
    //    {
    //        Nombre = nombre;
    //        Precio = precio;
    //        Stock = stock;
    //        Categoria = categoria;
    //    }
    //}

    //public class Proveedor
    //{
    //    public Guid Id { get; set; } = Guid.NewGuid();
    //    public Guid IdProducto { get; set; }
    //    public string Nombre { get; set; }
    //    public DateTime FechaAlta { get; set; } = DateTime.Now;
    //    public DateTime? FechaBaja { get; set; } // es null esta activo
    //    public long CUIT { get; set; } 
    //    public string Email { get; set; }
    //    public string Apellido { get; set; }

    //    public Guid IdUsuarioAlta { get; set; } 
    //    public List<Categoria> Categorias { get; set; } = new List<Categoria>(); //categorias de cada proveedor
        
    //    public EstadoProveedor estadoProveedor;

    //    public enum EstadoProveedor
    //    {
    //        INACTIVO,
    //        ACTIVO
    //    }

    //    public void DeshabilitarProveedor()
    //    {
    //        this.estadoProveedor = EstadoProveedor.INACTIVO;
    //    }

    //    public void HabilitarProveedor()
    //    {
    //        this.estadoProveedor = EstadoProveedor.ACTIVO;
    //    }



    //    //falta implementar
    //    public void AgregarCategoria(Categoria categoria)
    //    {
    //        if (!Categorias.Contains(categoria))
    //        {
    //            Categorias.Add(categoria);
    //            categoria.AgregarProveedor(this);
    //        }
    //    }
    //}

    //public class Categoria
    //{
    //    public Guid IdProducto { get; set; } = Guid.NewGuid();
    //    public string Descripcion { get; set; }
    //    public List<Proveedor> Proveedores { get; set; } = new List<Proveedor>();

    //    public void AgregarProveedor(Proveedor proveedor)
    //    {
    //        if (!Proveedores.Contains(proveedor))
    //        {
    //            Proveedores.Add(proveedor);
    //        }
    //    }
    //}






}









