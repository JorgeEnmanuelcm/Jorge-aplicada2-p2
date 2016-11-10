create table Articulos(
ArticuloId int primary key identity(1,1),
Descripcion varchar(32),
Existencia int
)

create table Ventas(
VentaId int primary key identity(1,1),
Fecha varchar(14),
Monto int
)

create table VentasDetalle(
Id int primary key identity(1,1),
VentaId int,
ArticuloId int,
Cantidad int,
Precio int
)

insert into Articulos(Descripcion,Existencia) values('Jabon', 200)
insert into Articulos(Descripcion,Existencia) values('Cepillo', 120)
insert into Articulos(Descripcion,Existencia) values('Papel de limpiar', 400)
select * from Articulos