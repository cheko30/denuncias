using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WebAppDenuncias.model;


namespace WebAppDenuncias
{
    public partial class Login : Page
    {
        Conexion conexion;
        protected void Page_Load(object sender, EventArgs e)
        {
            conexion = new Conexion();

        }

        protected void btnAcceder_Click(object sender, EventArgs e)
        {
            DataSet dataSet = validarUsuario();
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                Usuario usuario = new Usuario()
                {
                    id = Convert.ToInt32(dataSet.Tables[0].Rows[0][0].ToString()),
                    nombre = dataSet.Tables[0].Rows[0][1].ToString(),
                    apellidoPaterno = dataSet.Tables[0].Rows[0][2].ToString(),
                    correo = dataSet.Tables[0].Rows[0][7].ToString(),
                    rolFK = Convert.ToInt32(dataSet.Tables[0].Rows[0][9].ToString())
                };

                Session.Add("dataUser", usuario);
                Response.Redirect("Bienvenido.aspx");
            } 
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "alert(false, 'El usuario o contraseña son invalidos');", true);
                //lblLoginError.Visible = true;
            }  
        }

        private DataSet validarUsuario()
        {
            string sp = "spGestionUsuarios";
            Usuario usuario = new Usuario();
            usuario.correo = txtCorreo.Text;
            usuario.password = txtPass.Text;
            List<SqlParameter> listParametros = new List<SqlParameter>();
            listParametros.Add(new SqlParameter("@opcion", SqlDbType.Int) { Value = 1});
            listParametros.Add(new SqlParameter("@correo", SqlDbType.NVarChar) { Value = usuario.correo.Trim()});
            listParametros.Add(new SqlParameter("@password", SqlDbType.NVarChar) { Value = usuario.password.Trim()});
            return conexion.getData(sp, listParametros.ToArray());
           
        }

        protected void lblRegistrarse_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registro.aspx");
        }
    }
}