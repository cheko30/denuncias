<%@ Page Title="Login" Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebAppDenuncias.Login" %>

<!doctype html>
<html lang="en">
<head>



    <!-- Bootstrap core CSS -->
    <!--link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/Site.css" rel="stylesheet" / -->

    <!-- Bootstrap core CSS -->
    <link href="Content/bootstrap.min.css" rel="stylesheet" />

    <!-- Fontawesome -->
    <link href="FontAwesome/css/all.css" rel="stylesheet" />

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
    <link href="Content/signin.css" rel="stylesheet" />


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
    <body class="text-center">
    <form class="form-signin" runat="server">
        <img class="mb-4" src="images/justicia.png" alt="" width="72" height="72">
        <h1 class="h3 mb-3 font-weight-normal">Sistema de Denuncias</h1>

        <label for="txtCorreo" class="sr-only">Email address</label>
        <div class="input-group form-group">
            <div class="input-group-prepend">
                <span class="input-group-text" style="width: 58px; height: 47px;">
                    <i class="fas fa-envelope fa-2x" id="envolpe"></i>
                </span>
            </div>
            <asp:TextBox ID="txtCorreo" class="form-control" TextMode="Email" runat="server" placeholder="Correo electrónico" required autofocus />
        </div>

        <label for="txtPass" class="sr-only">Password</label>
        <div class="input-group form-group">
            <div class="input-group-prepend">
                <span class="input-group-text" style="width: 58px; height: 47px;">
                    <i class="fas fa-lock fa-2x" id="lock"></i>
                </span>
            </div>
            <asp:TextBox ID="txtPass" class="form-control" TextMode="Password" runat="server" placeholder="Contraseña" required autofocus />
        </div>

        <asp:Button ID="btnAcceder" runat="server" class="btn btn-lg btn-primary btn-block" Text="Acceder" OnClick="btnAcceder_Click" />
        <br />
        <br />

        <asp:LinkButton ID="lblRegistrarse" runat="server" CssClass="btn btn-link" OnClick="lblRegistrarse_Click">¿No tienes una cuenta? Registrate</asp:LinkButton>
        <p class="mt-5 mb-3 text-muted">&copy; 2017-2021</p>
    </form>
        </body>
</html>