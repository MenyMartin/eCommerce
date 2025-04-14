<%@ Page Title="Inicio" Language="C#" MasterPageFile="~/Master 1.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="eCommerce._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">

        <!-- Título -->
        <h1 class="text-center mb-4">Bienvenido a eCommerce</h1>

        <div class="container mt-4">
            <div class="row">

                <!-- Tarjeta 1 -->
                <div class="col-md-4 mb-4">
                    <div class="card shadow h-100">
                        <div class="card-header text-center bg-primary text-white">
                            Productos Destacados
                        </div>
                        <div class="card-body p-0">
                            <div id="carouselCard1" class="carousel slide" data-bs-ride="carousel" data-bs-interval="3000">
                                <div class="carousel-inner">
                                    <div class="carousel-item active">
                                        <img src="<%= ResolveUrl("~/img/pelacables/pelacables1.png") %>" class="d-block w-100" alt="Producto 1.2" />
                                    </div>
                                    <div class="carousel-item">
                                        <img src="<%= ResolveUrl("~/img/pelacables/pelacables2.png") %>" class="d-block w-100" alt="Producto 1.2" />
                                    </div>
                                    <div class="carousel-item">
                                        <img src="<%= ResolveUrl("~/img/pelacables/pelacables3.png") %>" class="d-block w-100" alt="Producto 1.3" />
                                    </div>
                                </div>
                                <button class="carousel-control-prev" type="button" data-bs-target="#carouselCard1" data-bs-slide="prev">
                                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                                    <span class="visually-hidden">Anterior</span>
                                </button>
                                <button class="carousel-control-next" type="button" data-bs-target="#carouselCard1" data-bs-slide="next">
                                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                                    <span class="visually-hidden">Siguiente</span>
                                </button>
                            </div>
                        </div>
                        <div class="card-footer text-muted text-center">
                            Pelacables Bremen
                        </div>
                    </div>
                </div>

                <!-- Tarjeta 2 -->
                <div class="col-md-4 mb-4">
                    <div class="card shadow h-100">
                        <div class="card-header text-center bg-primary text-white">
                            Productos Destacados
                        </div>
                        <div class="card-body p-0">
                            <div id="carouselCard2" class="carousel slide" data-bs-ride="carousel">
                                <div class="carousel-inner">
                                    <div class="carousel-item active">
                                        <img src="<%= ResolveUrl("~/img/taladro/taladro1.png") %>" class="d-block w-100" alt="Producto 2.1" />
                                    </div>
                                    <div class="carousel-item">
                                         <img src="<%= ResolveUrl("~/img/taladro/taladro2.png") %>" class="d-block w-100" alt="Producto 2.2" />
                                    </div>
                                    <div class="carousel-item">
                                         <img src="<%= ResolveUrl("~/img/taladro/taladro3.png") %>" class="d-block w-100" alt="Producto 2.3" />
                                    </div>
                                </div>
                                <button class="carousel-control-prev" type="button" data-bs-target="#carouselCard2" data-bs-slide="prev">
                                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                                    <span class="visually-hidden">Anterior</span>
                                </button>
                                <button class="carousel-control-next" type="button" data-bs-target="#carouselCard2" data-bs-slide="next">
                                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                                    <span class="visually-hidden">Siguiente</span>
                                </button>
                            </div>
                        </div>
                        <div class="card-footer text-muted text-center">
                            Taladro Pektra
                        </div>
                    </div>
                </div>

                <!-- Tarjeta 3 -->
                <div class="col-md-4 mb-4">
                    <div class="card shadow h-100">
                        <div class="card-header text-center bg-primary text-white">
                            Productos Destacados
                        </div>
                        <div class="card-body p-0">
                            <div id="carouselCard3" class="carousel slide" data-bs-ride="carousel">
                                <div class="carousel-inner">
                                        <div class="carousel-item active">
                                    <img src="<%= ResolveUrl("~/img/tester/tester1.png") %>" class="d-block w-100" alt="Producto 3.1" />

                                    </div>
                                    <div class="carousel-item">
                                        <img src="<%= ResolveUrl("~/img/tester/tester2.png") %>" class="d-block w-100" alt="Producto 3.2" />
                                    </div>
                                    <div class="carousel-item">
                                        <img src="<%= ResolveUrl("~/img/tester/tester3.png") %>" class="d-block w-100" alt="Producto 3.3" />
                                    </div>
                                </div>
                                <button class="carousel-control-prev" type="button" data-bs-target="#carouselCard3" data-bs-slide="prev">
                                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                                    <span class="visually-hidden">Anterior</span>
                                </button>
                                <button class="carousel-control-next" type="button" data-bs-target="#carouselCard3" data-bs-slide="next">
                                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                                    <span class="visually-hidden">Siguiente</span>
                                </button>
                            </div>
                        </div>
                        <div class="card-footer text-muted text-center">
                            Tester Brinna
                        </div>
                    </div>
                </div>

            </div>
        </div>

    </div>
</asp:Content>
