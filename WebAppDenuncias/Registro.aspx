<%@ Page Language="C#" Title="Registro" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="WebAppDenuncias.Registro" %>

<!doctype html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="Mark Otto, Jacob Thornton, and Bootstrap contributors">
    <meta name="generator" content="Jekyll v4.1.1">
    <title>Checkout example · Bootstrap</title>

    <link rel="canonical" href="https://getbootstrap.com/docs/4.5/examples/checkout/">

    <!-- Bootstrap core CSS -->
    <link href="Content/bootstrap.min.css" rel="stylesheet" />

    <!-- Fontawesome -->
    <link href="FontAwesome/css/all.css" rel="stylesheet" />
    <!-- Favicons -->
    <link rel="apple-touch-icon" href="/docs/4.5/assets/img/favicons/apple-touch-icon.png" sizes="180x180">
    <link rel="icon" href="/docs/4.5/assets/img/favicons/favicon-32x32.png" sizes="32x32" type="image/png">
    <link rel="icon" href="/docs/4.5/assets/img/favicons/favicon-16x16.png" sizes="16x16" type="image/png">
    <link rel="manifest" href="/docs/4.5/assets/img/favicons/manifest.json">
    <link rel="mask-icon" href="/docs/4.5/assets/img/favicons/safari-pinned-tab.svg" color="#563d7c">
    <link rel="icon" href="/docs/4.5/assets/img/favicons/favicon.ico">
    <meta name="msapplication-config" content="/docs/4.5/assets/img/favicons/browserconfig.xml">
    <meta name="theme-color" content="#563d7c">


    <style>
        .bd-placeholder-img {
            font-size: 1.125rem;
            text-anchor: middle;
            -webkit-user-select: none;
            -moz-user-select: none;
            -ms-user-select: none;
            user-select: none;
        }

        @media (min-width: 768px) {
            .bd-placeholder-img-lg {
                font-size: 3.5rem;
            }
        }
    </style>
    <!-- Custom styles for this template -->
    <link href="Content/form-validation.css" rel="stylesheet">

    <!-- Sweet alert-->
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@10"></script>

    <script>
        function alert(success, text) {
            if (success) {
                Swal.fire({
                    title: 'Éxito!',
                    text: text,
                    icon: 'success',
                    showConfirmButton: false,
                    timer: 2000
                });
            } else {
                Swal.fire({
                    title: 'Error!',
                    text: text,
                    icon: 'error',
                    showConfirmButton: false,
                    timer: 2000
                });
            }

        }
    </script>
</head>
<body class="bg-light">
    <div class="container">
        <form class="needs-validation" runat="server" novalidate>
        <div class="py-5 text-center">
            <img class="d-block mx-auto mb-4" src="images/justicia.png" alt="" width="72" height="72">
            <h2>Formulario de Registro</h2>
        </div>
        <div class="row">
            <div class="col-md-2"></div>
            <div class="col-md-8">
                
                    <div class="row">
                        <div class="col-md-4 mb-3">
                            <label for="txtNombre">Nombre</label>
                            <!--input type="text" class="form-control" id="nombre" placeholder="" value="" required -->
                            <asp:TextBox ID="txtNombre" class="form-control" placeholder="" value="" required runat="server"></asp:TextBox>
                            <div class="invalid-feedback">
                                Se requiere un nombre válido
                            </div>
                        </div>
                        <div class="col-md-4 mb-3">
                            <label for="txtAPaterno">Apellido Paterno</label>
                            <!--input type="text" class="form-control" id="aPaterno" placeholder="" value="" required -->
                            <asp:TextBox ID="txtAPaterno" class="form-control" placeholder="" value="" required runat="server"></asp:TextBox>
                            <div class="invalid-feedback">
                                Se requiere un apellido paterno válido
                            </div>
                        </div>
                        <div class="col-md-4 mb-3">
                            <label for="txtAMaterno">Apellido Materno</label>
                            <!--input type="text" class="form-control" id="aMaterno" placeholder="" value="" required -->
                            <asp:TextBox ID="txtAMaterno" class="form-control" placeholder="" value="" required runat="server"></asp:TextBox>
                            <div class="invalid-feedback">
                                Se requiere un apellido materno válido
                            </div>
                        </div>
                    </div>

                    <div class="mb-3">
                        <label for="txtEmail">Correo electrónico</label>
                        <div class="input-group">
                            <div class="input-group-prepend">
                                <span class="input-group-text">@</span>
                            </div>
                            <!--input type="email" class="form-control" id="email" placeholder="you@example.com" required-->
                            <asp:TextBox ID="txtEmail" class="form-control" TextMode="Email" placeholder="you@example.com" required runat="server"></asp:TextBox>
                            <div class="invalid-feedback">
                                Ingrese una dirección de correo electrónico.
                            </div>
                        </div>



                    </div>

                    <div class="mb-3">
                        <label for="txtPassword">Contraseña</label>
                        <div class="input-group">
                            <div class="input-group-prepend">
                                <span class="input-group-text">*</span>
                            </div>
                            <!--input type="text" class="form-control" id="password" placeholder="Contraseña" required-->
                            <asp:TextBox ID="txtPassword"  class="form-control" TextMode="Password" placeholder="Contraseña" required runat="server"></asp:TextBox>
                            <div class="invalid-feedback" style="width: 100%;">
                                La contraseña es requerida
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-3 mb-3">
                            <label for="txtEdad">Edad</label>
                            <!--input type="text" class="form-control" id="edad" placeholder="" required -->
                            <asp:TextBox ID="txtEdad"  class="form-control" required runat="server"></asp:TextBox>
                            <div class="invalid-feedback">
                                La edad es requerida
                            </div>
                        </div>
                        <div class="col-md-3 mb-3">
                            <label for="txtTelefono">Teléfono</label>
                            <!--input type="text" class="form-control" id="telefono" placeholder="" required -->
                            <asp:TextBox ID="txtTelefono"  class="form-control" required runat="server"></asp:TextBox>
                            <div class="invalid-feedback">
                                El telefono es requerido
                            </div>
                        </div>
                        <div class="col-md-3 mb-3">
                            <label for="ddlSexo">Sexo</label>
                            <asp:DropDownList CssClass="form-control" ID="ddlSexo" runat="server" required AppendDataBoundItems="true">
                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                <asp:ListItem Value="1">Femenino</asp:ListItem>
                                <asp:ListItem Value="2">Masculino</asp:ListItem>
                            </asp:DropDownList>
                            <!--select class="custom-select d-block w-100" id="sexo" required>
                                <option value="">Seleccionar</option>
                                <option>Femenino</option>
                                <option>Masculino</option>
                            </!--select-->
                            <div class="invalid-feedback">
                                El campo de sexo es obligatorio
                            </div>
                        </div>
                        <div class="col-md-3 mb-3">
                            <label for="ddlRol">Rol</label>
                            <asp:DropDownList CssClass="form-control" ID="ddlRol" runat="server" required AppendDataBoundItems="true">
                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                            </asp:DropDownList>
                            <!--select class="custom-select d-block w-100" id="sexo" required>
                                <option value="">Seleccionar</option>
                                <option>Femenino</option>
                                <option>Masculino</option>
                            </!--select-->
                            <div class="invalid-feedback">
                                El rol del usuario es obligatorio
                            </div>
                        </div>
                       
                        
                    </div>
                    <div class="row">
                        <div class="col-md-6 mb-3">
                            <asp:Button ID="btnRegistrar" runat="server" class="btn btn-lg btn-primary btn-block" Text="Registrar" OnClick="btnRegistrar_Click"/>
                        </div>
                        <div class="col-md-6 mb-3">
                            <asp:Button ID="btnCancelar" runat="server" class="btn btn-lg btn-danger btn-block" Text="Cancelar" OnClick="btnCancelar_Click"/>
                        </div>
                    </div>
                <asp:LinkButton ID="lblLogin" runat="server" CssClass="btn btn-link" OnClick="lblLogin_Click">¿Ya tienes cuenta? Inicia sesión</asp:LinkButton>
            </div>
            <div class="col-md-2"></div>

        </div>
        
        </form>
        <footer class="my-5 pt-5 text-muted text-center text-small">
            <p class="mb-1">&copy; 2017-2020 Company Name</p>
            <ul class="list-inline">
                <li class="list-inline-item"><a href="#">Privacy</a></li>
                <li class="list-inline-item"><a href="#">Terms</a></li>
                <li class="list-inline-item"><a href="#">Support</a></li>
            </ul>
        </footer>
    </div>
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script>window.jQuery || document.write('<script src="Scripts/jquery.slim.min.js"><\/script>')</script>
    <script src="/docs/4.5/dist/js/bootstrap.bundle.min.js" integrity="sha384-ho+j7jyWK8fNQe+A12Hb8AhRq26LrZ/JpcUGGOn+Y7RsweNrtN/tE3MoK7ZeZDyx" crossorigin="anonymous"></script>
    <script src="Scripts/form-validation.js"></script>
</body>
</html>

