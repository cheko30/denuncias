<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebAppDenuncias._Default" %>

<!doctype html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="Mark Otto, Jacob Thornton, and Bootstrap contributors">
    <meta name="generator" content="Hugo 0.80.0">
    <title>Acceso</title>

    <link rel="canonical" href="https://getbootstrap.com/docs/4.6/examples/sign-in/">

    <!-- Bootstrap core CSS -->
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    
    <!-- Favicons -->
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
    <link href="Content/signin.css" rel="stylesheet" />
   
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
<body class="text-center">

    <form class="form-signin" runat="server">
        <img class="mb-4" src="images/justicia.png" alt="" width="72" height="72">
        <h1 class="h3 mb-3 font-weight-normal">Sistema de Denuncias</h1>
        
        <label for="txtCorreo" class="sr-only">Email address</label>
        <asp:TextBox ID="txtCorreo" class="form-control" TextMode="Email" runat="server" placeholder="Correo electronico" required autofocus></asp:TextBox>

        <label for="txtPass" class="sr-only">Password</label>
        <asp:TextBox ID="txtPass" class="form-control" TextMode="Password" runat="server" placeholder="Contraseña" required autofocus></asp:TextBox>
               
        <asp:Button ID="btnAcceder" runat="server" class="btn btn-lg btn-primary btn-block" Text="Acceder" OnClick="btnAcceder_Click" />
        <br />
        <asp:LinkButton ID="lblRegistrarse" runat="server" CssClass="alert alert-info" OnClick="lblRegistrarse_Click">Registrarse</asp:LinkButton>
        <p class="mt-5 mb-3 text-muted">&copy; 2017-2021</p>
    </form>



</body>
</html>

