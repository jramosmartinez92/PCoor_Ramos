CREATE TABLE c_Empleado (
    idEmpleado INT IDENTITY(1,1) PRIMARY KEY,
    nombres VARCHAR(50) NOT NULL,
    apellidos VARCHAR(50) NOT NULL,
    usuario VARCHAR(50) NOT NULL UNIQUE,
    clave VARCHAR(50) NOT NULL,
    activo BIT NOT NULL
);

INSERT INTO c_Empleado (nombres, apellidos, usuario, clave, activo)
VALUES 
('Carlos', 'Morales', 'cmorales', '1234', 1),
('Ana', 'Ramírez', 'aramirez', '1234', 1),
('Luis', 'Torres', 'ltorres', '1234', 1);


CREATE TABLE c_Consumidor (
    idConsumidor INT IDENTITY(1,1) PRIMARY KEY,
    nombreConsumidor VARCHAR(50) NOT NULL,
    apellidoConsumidor VARCHAR(50) NOT NULL,
    direccion VARCHAR(50) NOT NULL,
    correoElectronico VARCHAR(50) NOT NULL,
    duiConsumidor VARCHAR(10) NOT NULL UNIQUE,
    activo BIT NOT NULL
);


CREATE TABLE c_Estado (
    idEstado INT PRIMARY KEY,
    nombreEstado VARCHAR(50) NOT NULL
);


INSERT INTO c_Estado (idEstado, nombreEstado) VALUES
(1, 'Pendiente de Clasificar'),
(2, 'Validado como Reclamo'),
(3, 'Clasificado como Asesoría'),
(4, 'Clasificado como Aviso de Infracción');


CREATE TABLE t_Reclamo (
    idReclamo INT IDENTITY(1,1) PRIMARY KEY,
    nombreProveedor VARCHAR(50) NOT NULL,
    direccionProveedor VARCHAR(50) NOT NULL,
    detalleReclamo VARCHAR(250) NOT NULL,
    telefonoProveedor VARCHAR(10) NOT NULL,
    montoReclamado DECIMAL(18,2) NOT NULL,
    fechaIngreso DATETIME NOT NULL,
    fechaRevision DATETIME NULL,
    idEmpleado INT NOT NULL,
    idConsumidor INT NOT NULL,
    idEstado INT NOT NULL,
    activo BIT NOT NULL,
    FOREIGN KEY (idEmpleado) REFERENCES c_Empleado(idEmpleado),
    FOREIGN KEY (idConsumidor) REFERENCES c_Consumidor(idConsumidor),
    FOREIGN KEY (idEstado) REFERENCES c_Estado(idEstado)
);


CREATE TABLE t_Asesoria (
    idAsesoria INT IDENTITY(1,1) PRIMARY KEY,
    fechaIngreso DATETIME NOT NULL,
    motivoAsesoria VARCHAR(500) NOT NULL,
    respuestaAsesoria VARCHAR(500) NOT NULL,
    idReclamo INT NOT NULL,
    activo BIT NOT NULL,
    FOREIGN KEY (idReclamo) REFERENCES t_Reclamo(idReclamo)
);


CREATE TABLE t_Aviso (
    idAviso INT IDENTITY(1,1) PRIMARY KEY,
    fechaIngreso DATETIME NOT NULL,
    detalleAviso VARCHAR(500) NOT NULL,
    idReclamo INT NOT NULL,
    activo BIT NOT NULL,
    FOREIGN KEY (idReclamo) REFERENCES t_Reclamo(idReclamo)
);