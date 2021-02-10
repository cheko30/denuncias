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
    public partial class Registro : Page
    {
        Conexion conexion;
        int operacion;
        protected void Page_Load(object sender, EventArgs e)
        {
            conexion = new Conexion();
            if (!IsPostBack)
            {
                getRoles();
            }

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            operacion = 2;
            Usuario usuario = new Usuario();
            usuario.nombre = txtNombre.Text;
            usuario.apellidoPaterno = txtAPaterno.Text;
            usuario.apellidoMaterno = txtAMaterno.Text;
            usuario.sexo = getSexo(ddlSexo.SelectedValue);
            usuario.edad = Convert.ToInt32(txtEdad.Text);
            usuario.telefono = txtTelefono.Text;
            usuario.correo = txtEmail.Text;
            usuario.password = txtPassword.Text;
            usuario.rolFK = ddlRol.SelectedIndex;

            if (existeUsuario(3))
            {

                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "alert(false, 'El usuario ya ha sido registrado, intente con otro correo');", true);
                limpiarFormulario();
            }
            else
            {
                if (registrarUsuario(usuario, operacion))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "alert(true, 'El usuario se registro con éxito');", true);
                    limpiarFormulario();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "alert(false, 'Ocurrio un error al registrar el usuaior');", true);
                }
            }
        }

        /// <summary>
        /// Asigna la descripcion del sexo
        /// </summary>
        /// <param name="sexo"></param>
        /// <returns>La descripcion del sexo</returns>
        private string getSexo(string sexo)
        {
            string sexoDescripcion = null;
            switch (sexo)
            {
                case "1":
                    sexoDescripcion = "Femenino";
                    break;
                case "2":
                    sexoDescripcion = "Masculino";
                    break;
                default:
                    break;
            }
            return sexoDescripcion;
        }

        private bool registrarUsuario(Usuario usuario, int operacion)
        {

            List<SqlParameter> listParametros = new List<SqlParameter>();
            listParametros.Add(new SqlParameter("@opcion", SqlDbType.Int) { Value = operacion });
            listParametros.Add(new SqlParameter("@nombre", SqlDbType.NVarChar) { Value = usuario.nombre});
            listParametros.Add(new SqlParameter("@aPaterno", SqlDbType.NVarChar) { Value = usuario.apellidoPaterno});
            listParametros.Add(new SqlParameter("@aMaterno", SqlDbType.NVarChar) { Value = usuario.apellidoMaterno});
            listParametros.Add(new SqlParameter("@sexo", SqlDbType.NVarChar) { Value = usuario.sexo});
            listParametros.Add(new SqlParameter("@edad", SqlDbType.NVarChar) { Value = usuario.edad});
            listParametros.Add(new SqlParameter("@telefono", SqlDbType.NVarChar) { Value = usuario.telefono});
            listParametros.Add(new SqlParameter("@correo", SqlDbType.NVarChar) { Value = usuario.correo});
            listParametros.Add(new SqlParameter("@password", SqlDbType.NVarChar) { Value = usuario.password});
            listParametros.Add(new SqlParameter("@rol", SqlDbType.NVarChar) { Value = usuario.rolFK});


            return conexion.iudData("spGestionUsuarios", listParametros.ToArray());

        }

        private void limpiarFormulario()
        {
            txtNombre.Text = "";
            txtAPaterno.Text = "";
            txtAMaterno.Text = "";
            ddlSexo.SelectedIndex = 0;
            txtEdad.Text = "";
            txtTelefono.Text = "";
            txtEmail.Text = "";
            txtPassword.Text = "";

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiarFormulario();
        }

        private void getRoles()
        {
            operacion = 1;
            List<SqlParameter> listParametros = new List<SqlParameter>();
            listParametros.Add(new SqlParameter("@opcion", SqlDbType.Int) { Value = operacion });
            DataSet roles = conexion.getData("spGestionRoles", listParametros.ToArray());
            if (roles.Tables[0].Rows.Count > 0)
            {
                ddlRol.DataSource = roles;
                ddlRol.DataValueField = "id";
                ddlRol.DataValueField = "descripcion";
                ddlRol.DataBind();
            }
        }

        protected void lblLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        private bool existeUsuario(int operacion)
        {
            bool existe = false;
            string sp = "spGestionUsuarios";
            Usuario usuario = new Usuario();
            usuario.correo = txtEmail.Text;
            List<SqlParameter> listParametros = new List<SqlParameter>();
            listParametros.Add(new SqlParameter("@opcion", SqlDbType.Int) { Value = operacion });
            listParametros.Add(new SqlParameter("@correo", SqlDbType.NVarChar) { Value = usuario.correo.Trim() });
            DataSet dataSet = conexion.getData(sp, listParametros.ToArray());
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                existe = true;
            }

            return existe;
        }
    }
}