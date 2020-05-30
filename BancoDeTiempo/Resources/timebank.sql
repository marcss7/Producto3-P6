/* Crear base de datos */
if not exists(select * from sys.databases where name = 'timebank')
	CREATE DATABASE timebank
go

/* Seleccionar base de datos */
USE timebank;

/* Crear tabla categorías */
if not exists (select * from sysobjects where name='categorias' and xtype='U')
	CREATE TABLE categorias (
	id_categoria VARCHAR(5),
	nombre_categoria VARCHAR(25) UNIQUE NOT NULL,
	ruta_imagen VARCHAR(250),
	PRIMARY KEY (id_categoria)
	)
go

/* Crear tabla usuarios */
if not exists (select * from sysobjects where name='usuarios' and xtype='U')
	CREATE TABLE usuarios (
	id_usuario VARCHAR(9),
	nombre_usuario VARCHAR(50) NOT NULL,
	pass VARCHAR(16) NOT NULL,
	alias VARCHAR(15),
	descripcion VARCHAR(250),
	email VARCHAR(20) UNIQUE NOT NULL,
	telefono INT,
	fecha_nacimiento DATETIME,
	balance DECIMAL(4,2),
	PRIMARY KEY (id_usuario)
	)
go

/* Crear tipo de servicios */
if not exists (select * from sysobjects where name='tipo_servicio' and xtype='U')
	CREATE TABLE tipo_servicio (
	id_tipo_servicio VARCHAR(1),
	tipo_servicio VARCHAR(10) NOT NULL,
	PRIMARY KEY (id_tipo_servicio)
	)
go

/* Crear tabla servicios */
if not exists (select * from sysobjects where name='servicios' and xtype='U')
CREATE TABLE servicios (
	id_servicio VARCHAR(10),
	titulo VARCHAR(25) NOT NULL,
	descripcion VARCHAR(25),
	id_usuario VARCHAR(9),
	id_categoria VARCHAR(5),
	fecha_creacion DATETIME,
	tipo_servicio VARCHAR(1),
	PRIMARY KEY (id_servicio),
	CONSTRAINT fk_usuarios_1 FOREIGN KEY (id_usuario) REFERENCES usuarios (id_usuario) ON DELETE CASCADE ON UPDATE CASCADE,
	CONSTRAINT fk_categorias FOREIGN KEY (id_categoria) REFERENCES categorias (id_categoria) ON DELETE CASCADE ON UPDATE CASCADE,
	CONSTRAINT fk_tipo_servicio FOREIGN KEY (tipo_servicio) REFERENCES tipo_servicio (id_tipo_servicio) ON DELETE CASCADE ON UPDATE CASCADE
	)
go

/* Crear tabla solicitudes */
if not exists (select * from sysobjects where name='solicitudes' and xtype='U')
	CREATE TABLE solicitudes (
	id_solicitud VARCHAR(10),
	id_emisor VARCHAR(9) NOT NULL,
	concepto VARCHAR(10),
	fecha_creacion DATETIME,
	aceptada BIT DEFAULT 0,
	PRIMARY KEY (id_solicitud),
	CONSTRAINT fk_usuarios_2 FOREIGN KEY (id_emisor) REFERENCES usuarios (id_usuario) ON DELETE CASCADE ON UPDATE CASCADE,
	CONSTRAINT fk_servicios_2 FOREIGN KEY (concepto) REFERENCES servicios (id_servicio) ON DELETE NO ACTION ON UPDATE NO ACTION
	)
go

/* Crear tabla movimientos */
if not exists (select * from sysobjects where name='movimientos' and xtype='U')
	CREATE TABLE movimientos (
	id_movimiento VARCHAR(10),
	usuario_origen VARCHAR(9) NOT NULL,
	usuario_destino VARCHAR(9) NOT NULL,
	concepto VARCHAR(10) NOT NULL,
	comentarios VARCHAR(50),
	horas FLOAT NOT NULL,
	fecha DATETIME,
	PRIMARY KEY (id_movimiento),
	CONSTRAINT fk_usuarios_3 FOREIGN KEY (usuario_origen) REFERENCES  usuarios (id_usuario) ON DELETE CASCADE ON UPDATE CASCADE,
	CONSTRAINT fk_usuarios_4 FOREIGN KEY (usuario_destino) REFERENCES usuarios (id_usuario) ON DELETE NO ACTION ON UPDATE NO ACTION,
	CONSTRAINT fk_servicios_3 FOREIGN KEY (concepto) REFERENCES servicios (id_servicio) ON DELETE NO ACTION ON UPDATE NO ACTION
	)
go

/* Crear tabla facturas */
if not exists (select * from sysobjects where name='facturas' and xtype='U')
	CREATE TABLE facturas (
	id_factura VARCHAR(10),
	usuario_emisor VARCHAR(9) NOT NULL,
	usuario_receptor VARCHAR(9) NOT NULL,
	concepto VARCHAR(10) NOT NULL,
	importe FLOAT NOT NULL,
	fecha DATETIME,
	PRIMARY KEY (id_factura),
	CONSTRAINT fk_usuarios_5 FOREIGN KEY (usuario_emisor) REFERENCES  usuarios (id_usuario) ON DELETE CASCADE ON UPDATE CASCADE,
	CONSTRAINT fk_usuarios_6 FOREIGN KEY (usuario_receptor) REFERENCES usuarios (id_usuario) ON DELETE NO ACTION ON UPDATE NO ACTION,
	CONSTRAINT fk_servicios_4 FOREIGN KEY (concepto) REFERENCES servicios (id_servicio) ON DELETE NO ACTION ON UPDATE NO ACTION
	)
go

/* Insertar registros categorias */
IF NOT EXISTS (SELECT * FROM categorias WHERE id_categoria = 'DmGOm')
    INSERT INTO categorias VALUES ('DmGOm','Deporte','resources/1.jpg')
GO

IF NOT EXISTS (SELECT * FROM categorias WHERE id_categoria = 'nl1zR')
    INSERT INTO categorias VALUES ('nl1zR','Arte','resources/2.jpg')
GO

IF NOT EXISTS (SELECT * FROM categorias WHERE id_categoria = 'NBpJI')
    INSERT INTO categorias VALUES ('NBpJI','Informática','resources/3.jpg')
GO

IF NOT EXISTS (SELECT * FROM categorias WHERE id_categoria = 'ctBlZ')
    INSERT INTO categorias VALUES ('ctBlZ','Cocina','resources/4.jpg')
GO

IF NOT EXISTS (SELECT * FROM categorias WHERE id_categoria = 'nx6g7')
    INSERT INTO categorias VALUES ('nx6g7','Idiomas','resources/5.jpg')
GO


/* Insertar registros usuarios */
IF NOT EXISTS (SELECT * FROM usuarios WHERE id_usuario = '50424556D')
    INSERT INTO usuarios VALUES ('50424556D','Jorge López','password1', 'jlopez', 'Soy bueno tocando la guitarra española', 'jlopez@gmail.com', 656888333, '18-06-1993', 10)
GO

IF NOT EXISTS (SELECT * FROM usuarios WHERE id_usuario = '56324645X')
    INSERT INTO usuarios VALUES ('56324645X','Roger Gómez','password2', 'rgomez', 'Se me da bien cocinar', 'rgomez@gmail.com', 677888446, '21-02-1990', 10)
GO

IF NOT EXISTS (SELECT * FROM usuarios WHERE id_usuario = '83800110R')
    INSERT INTO usuarios VALUES ('83800110R','Laura Mateos','password3', 'lmateos', 'Trabajo como programadora en una multinacional', 'lmateos@gmail.com', 645587344, '08-08-1995', 10)
GO

IF NOT EXISTS (SELECT * FROM usuarios WHERE id_usuario = '62040335C')
    INSERT INTO usuarios VALUES ('62040335C','Carlos Moreso','password4', 'cmoreso', 'Soy entrenador personal de fitness', 'cmoreso@gmail.com', 682421789, '12-05-1989', 10)
GO

IF NOT EXISTS (SELECT * FROM usuarios WHERE id_usuario = '90840752K')
    INSERT INTO usuarios VALUES ('90840752K','Marta Sanz','password5', 'msanz', 'Soy profesora particular de inglés', 'msanz@gmail.com', 625311846, '27-11-1988', 10)
GO


/* Insertar registros tipos de servicios */
IF NOT EXISTS (SELECT * FROM tipo_servicio WHERE id_tipo_servicio = '1')
    INSERT INTO tipo_servicio VALUES ('1','Formación')
GO

IF NOT EXISTS (SELECT * FROM tipo_servicio WHERE id_tipo_servicio = '2')
    INSERT INTO tipo_servicio VALUES ('2','Cuidados')
GO

IF NOT EXISTS (SELECT * FROM tipo_servicio WHERE id_tipo_servicio = '3')
    INSERT INTO tipo_servicio VALUES ('3','Doméstico')
GO

IF NOT EXISTS (SELECT * FROM tipo_servicio WHERE id_tipo_servicio = '4')
    INSERT INTO tipo_servicio VALUES ('4','Asesoría')
GO

IF NOT EXISTS (SELECT * FROM tipo_servicio WHERE id_tipo_servicio = '5')
    INSERT INTO tipo_servicio VALUES ('5','Atención')
GO


/* Insertar registros servicios */
IF NOT EXISTS (SELECT * FROM servicios WHERE id_servicio = 'NpokLNh6dL')
    INSERT INTO servicios VALUES ('NpokLNh6dL','Taller de cocina japonesa','¡Sorprende a tus visitas!', '56324645X', 'ctBlZ', '24-01-2020', 1)
GO

IF NOT EXISTS (SELECT * FROM servicios WHERE id_servicio = 'NdgpRjGPAW')
    INSERT INTO servicios VALUES ('NdgpRjGPAW','Circuito de crossfit','¡Anímate a entrenar!', '62040335C', 'DmGOm', '05-02-2020', 2)
GO

IF NOT EXISTS (SELECT * FROM servicios WHERE id_servicio = 'hfbWxIYpYk')
    INSERT INTO servicios VALUES ('hfbWxIYpYk','Preparación FCE-B2','Se requiere nivel B1', '90840752K', 'nx6g7', '29-04-2020', 1)
GO

IF NOT EXISTS (SELECT * FROM servicios WHERE id_servicio = 'rUndBSlem7')
    INSERT INTO servicios VALUES ('rUndBSlem7','Programar en C++','Programa desde 0', '83800110R', 'NBpJI', '04-05-2020', 1)
GO

IF NOT EXISTS (SELECT * FROM servicios WHERE id_servicio = 'EPRXeR2Sv3')
    INSERT INTO servicios VALUES ('EPRXeR2Sv3','Clases de guitarra','Solo clases a domicilio', '50424556D', 'nl1zR', '23-5-2020', 1)
GO

/* Insertar registros solicitudes */
IF NOT EXISTS (SELECT * FROM solicitudes WHERE id_solicitud = 'X64Oy4zBAj')
    INSERT INTO solicitudes VALUES ('X64Oy4zBAj','50424556D','rUndBSlem7', '09-02-2020', 0)
GO

IF NOT EXISTS (SELECT * FROM solicitudes WHERE id_solicitud = 'dL5mW1263p')
    INSERT INTO solicitudes VALUES ('dL5mW1263p','56324645X','NdgpRjGPAW', '15-03-2020', 0)
GO

IF NOT EXISTS (SELECT * FROM solicitudes WHERE id_solicitud = 'N6jkZGl8Ye')
    INSERT INTO solicitudes VALUES ('N6jkZGl8Ye','83800110R','hfbWxIYpYk', '01-05-2020', 0)
GO

IF NOT EXISTS (SELECT * FROM solicitudes WHERE id_solicitud = 'ovZfbiKQCt')
    INSERT INTO solicitudes VALUES ('ovZfbiKQCt','62040335C','EPRXeR2Sv3', '08-05-2020', 0)
GO

IF NOT EXISTS (SELECT * FROM solicitudes WHERE id_solicitud = 'gnuAgvXJe9')
    INSERT INTO solicitudes VALUES ('gnuAgvXJe9','90840752K','NpokLNh6dL', '25-05-2020', 0)
GO

/* Insertar registros movimientos */
IF NOT EXISTS (SELECT * FROM movimientos WHERE id_movimiento = 'X0MMNtdkMG')
    INSERT INTO movimientos VALUES ('X0MMNtdkMG','50424556D','83800110R','rUndBSlem7','Sesión de dos horas: Introducción a C++',2, '16-02-2020')
GO

IF NOT EXISTS (SELECT * FROM movimientos WHERE id_movimiento = '1Ltugs9OE2')
    INSERT INTO movimientos VALUES ('1Ltugs9OE2','56324645X','62040335C','NdgpRjGPAW','Clase de crossfit guiada durante una hora',1, '19-03-2020')
GO

IF NOT EXISTS (SELECT * FROM movimientos WHERE id_movimiento = 'd8iRFSYhyv')
    INSERT INTO movimientos VALUES ('d8iRFSYhyv','83800110R','90840752K','hfbWxIYpYk','Sesión de una hora de speaking',1, '25-05-2020')
GO

IF NOT EXISTS (SELECT * FROM movimientos WHERE id_movimiento = 'buyRcYUF0D')
    INSERT INTO movimientos VALUES ('buyRcYUF0D','62040335C','50424556D','EPRXeR2Sv3','Primera sesión: aprender acordes',1.5,'17-05-2020')
GO

IF NOT EXISTS (SELECT * FROM movimientos WHERE id_movimiento = 'FxHVVl3MrV')
    INSERT INTO movimientos VALUES ('FxHVVl3MrV','90840752K','56324645X','NpokLNh6dL','Tercera sesión: aprender a hacer nigiris',2,'27-05-2020')
GO