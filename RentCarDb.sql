create database RentCarDB

go 
use RentCarDB

go
create table Marca(
idMarca int not null constraint pk_Marca primary key identity(1,1),
Descripcion varchar(200) not null,
Estado char(1) check(Estado in ('A', 'I'))
);

go 
select * from Marca

go
create table Modelo(
idModelo int not null constraint pk_Modelo primary key identity(1,1),
Id_marca int not null,
Descripcion varchar(200) not null,
Estado bit not null
constraint fk_Marca foreign key (Id_marca) references Marca(idMarca)
);

select * from Modelo

alter table Modelo alter column Estado char(1)

go
create table Tipo_vehiculo(
idTipoVehiculo int not null constraint pk_TipoVehiculo primary key identity(1,1),
Descripcion varchar(200) not null,
Estado char(1) check (Estado in ('A','I'))
);


go
create table Tipo_combustible(
idTipoCombustible int not null constraint pk_TipoCombustible primary key identity(1,1),
Descripcion varchar(200) not null,
Estado char(1) check(Estado in('A','I'))
);

go
create table Vehiculo(
idVehiculo int not null constraint pk_Vehiculo primary key identity(1,1),
IdMarca int not null,
IdModelo int not null,
IdTipoVehiculo int not null,
IdTipoCombustible int not null,
No_chahis int not null,
No_motor int not null,
No_placa int not null,
Descripcion varchar(200) not null,
Estado char(1) check(Estado in('D','R','M','I')) not null,
constraint fk_TipoVehiculo foreign key(IdTipoVehiculo) references Tipo_vehiculo(idTipoVehiculo),
constraint fk_MarcaVehiculo foreign key(IdMarca) references Marca(idMarca),
constraint fk_Modelo foreign key(IdModelo) references Modelo(idModelo),
constraint fk_TipoCombustible foreign key(IdTipocombustible) references Tipo_combustible(idTipoCombustible)
);

go
create table cliente(
idCliente int not null constraint pk_Cliente primary key identity(1,1),
Nombre varchar(50) not null,
Cedula varchar(11) not null,
No_tarjeta_cr varchar(15) not null,
Limite_cr varchar(50) not null,
Tipo_persona char(1) check(Tipo_persona in ('F','J')) not null,
Estado char(1) check(Estado in('A','I')) not null
);

alter table cliente alter column No_tarjeta_cr varchar(16)

go 
create table Empleado(
idEmpleado int not null constraint pk_Empleado primary key identity(1,1),
Nombre varchar(50) not null,
Cedula varchar(11) not null,
Tanda_Labor char(1) check(Tanda_Labor in('M','V','N')) not null,
Porciento_comision int,
fecha_ingreso datetime,
usuario varchar(100),
password varchar(100),
Estado char(1) check(Estado in('A','I')) not null
);

alter table Empleado add 

insert into Empleado(Nombre, Cedula, Tanda_Labor, Porciento_comision, usuario, password, Estado) 
values('Gabriel Pozo', '40237467879','M', 15, 'gpozo', 'Pozo', 'A');

select * from Empleado

alter table Empleado alter column Cedula varchar(11)

go
create table Inspeccion(
idInspeccion int not null constraint pk_Inspeccion primary key identity(1,1),
IdVehiculo int not null,
IdCliente int not null,
IdEmpleado int not null,
Ralladura char(1) check(Ralladura in ('S','N')) not null,
Cantidad_combustible varchar(10) not null,
Goma_respuesta char(1) check(Goma_respuesta in ('S','N')) not null,
Gato char(1) check(Gato in ('S','N')) not null,
Rotura_cristal char(1) check(Rotura_cristal in ('S','N')) not null,
goma_sup_izq char(1) check(goma_sup_izq in('B','M')) not null,
goma_sup_der char(1) check(goma_sup_der in('B','M')) not null,
goma_inf_izq char(1) check(goma_inf_izq in('B','M')) not null,
goma_inf_der char(1) check(goma_inf_der in('B','M')) not null,
fecha datetime,
Empleado int not null,
Estado char(1) check(Estado in('A','I')) not null,
constraint fk_InspeccionVehiculo foreign key (IdVehiculo) references Vehiculo(idVehiculo),
constraint fk_InspeccionCliente foreign key (IdCliente) references Cliente(idCliente),
constraint fk_InspeccionEmpleado foreign key (IdEmpleado) references Empleado(idEmpleado)
);


alter table Inspeccion drop column Empleado

select * from Renta_Devolucion
select * from Vehiculo


go
create table Renta_Devolucion(
idRentaDevolucion int not null constraint pk_RentaDevolucion primary key identity(1,1),
IdEmpleado int not null,
IdVehiculo int not null,
IdCliente int not null,
FechaRenta datetime not null,
FechaDevolucion datetime not null,
MontoDia decimal(13,1) not null,
CantidadDias varchar(30) not null,
Comentario varchar(255),
Estado char(1) check(Estado in('A','I'))not null
constraint fk_RentaDevolucionEmpleado foreign key(IdEmpleado) references Empleado(idEmpleado),
constraint fk_RentaDevolucionvehiculo foreign Key(IdVehiculo) references Vehiculo(idVehiculo),
constraint fk_RentaDevolucionCliente foreign key(IdCliente) references Cliente(idCliente)
);

go
create table Renta_Devolucion_Copia(
idRentaDevolucion int not null constraint pk_RentaDevolucionCopia primary key identity(1,1),
IdEmpleado int not null,
IdVehiculo int not null,
IdCliente int not null,
FechaRenta datetime not null,
FechaDevolucion datetime not null,
MontoDia decimal(13,1) not null,
CantidadDias varchar(30) not null,
Comentario varchar(255),
Estado char(1) check(Estado in('A','I'))not null
constraint fk_RentaDevolucionEmpleadoCopia foreign key(IdEmpleado) references Empleado(idEmpleado),
constraint fk_RentaDevolucionvehiculoCopia foreign Key(IdVehiculo) references Vehiculo(idVehiculo),
constraint fk_RentaDevolucionClienteCopia foreign key(IdCliente) references Cliente(idCliente)
);

select * from Renta_Devolucion_Copia

--------------------------------------------------------------------
go
create trigger Renta on Renta_Devolucion after insert
 as
 declare @IdVehiculo int
 select @IdVehiculo = IdVehiculo from inserted

 update Vehiculo set Estado = 'R' where idVehiculo = @IdVehiculo
 go
 


--------------------------------------------

create trigger DevolucionCopia on Renta_Devolucion after update
as
declare @IdVehiculo int

select @IdVehiculo = idVehiculo from deleted;

update Vehiculo set Estado = 'D' where IdVehiculo = @IdVehiculo
go


create trigger DevolucionCopia on Renta_Devolucion after update
as
declare @IdVehiculo int

select @IdVehiculo = idVehiculo from deleted;

update Vehiculo set Estado = 'D' where IdVehiculo = @IdVehiculo
go
