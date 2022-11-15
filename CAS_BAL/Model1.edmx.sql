
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/11/2022 20:05:49
-- Generated from EDMX file: E:\CAS-master\CAS-master\CAS_BAL\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [test];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_128]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Doctors] DROP CONSTRAINT [FK_128];
GO
IF OBJECT_ID(N'[dbo].[FK_153]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK_153];
GO
IF OBJECT_ID(N'[dbo].[FK_160]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Appointments] DROP CONSTRAINT [FK_160];
GO
IF OBJECT_ID(N'[dbo].[FK_163]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Messages] DROP CONSTRAINT [FK_163];
GO
IF OBJECT_ID(N'[dbo].[FK_166]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Messages] DROP CONSTRAINT [FK_166];
GO
IF OBJECT_ID(N'[dbo].[FK_169]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Appointments] DROP CONSTRAINT [FK_169];
GO
IF OBJECT_ID(N'[dbo].[FK_27]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Doctors] DROP CONSTRAINT [FK_27];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Appointments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Appointments];
GO
IF OBJECT_ID(N'[dbo].[Doctors]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Doctors];
GO
IF OBJECT_ID(N'[dbo].[Medicines]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Medicines];
GO
IF OBJECT_ID(N'[dbo].[Messages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Messages];
GO
IF OBJECT_ID(N'[dbo].[Roles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Roles];
GO
IF OBJECT_ID(N'[dbo].[Specializations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Specializations];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Appointments'
CREATE TABLE [dbo].[Appointments] (
    [AppointmentId] int IDENTITY(1,1) NOT NULL,
    [StartDateTime] datetime  NOT NULL,
    [Status] varchar(10)  NOT NULL,
    [Details] varchar(200)  NOT NULL,
    [IsApprove] bit  NOT NULL,
    [PatientId] int  NOT NULL,
    [DoctorId] int  NOT NULL
);
GO

-- Creating table 'Doctors'
CREATE TABLE [dbo].[Doctors] (
    [DoctorId] int IDENTITY(1,1) NOT NULL,
    [IsAavailable] bit  NOT NULL,
    [SpecializationId] int  NOT NULL,
    [UserId] int  NOT NULL,
    [Timings] varchar(50)  NOT NULL
);
GO

-- Creating table 'Medicines'
CREATE TABLE [dbo].[Medicines] (
    [MedicineId] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(50)  NOT NULL,
    [Price] float  NOT NULL,
    [Stock] int  NOT NULL,
    [IsAvailable] bit  NOT NULL,
    [Tax] float  NOT NULL,
    [IsActive] bit  NOT NULL
);
GO

-- Creating table 'Messages'
CREATE TABLE [dbo].[Messages] (
    [MessageId] int IDENTITY(1,1) NOT NULL,
    [MessageTime] datetime  NOT NULL,
    [Message1] varchar(200)  NOT NULL,
    [Status] varchar(100)  NOT NULL,
    [RecieverId] int  NOT NULL,
    [SenderId] int  NOT NULL
);
GO

-- Creating table 'Roles'
CREATE TABLE [dbo].[Roles] (
    [RoleId] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(50)  NOT NULL
);
GO

-- Creating table 'Specializations'
CREATE TABLE [dbo].[Specializations] (
    [SpecializationId] int IDENTITY(1,1) NOT NULL,
    [SpecializationName] varchar(50)  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [UserId] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(50)  NOT NULL,
    [Phone] varchar(11)  NOT NULL,
    [Address] varchar(50)  NOT NULL,
    [DOB] datetime  NOT NULL,
    [Gender] varchar(10)  NOT NULL,
    [Email] varchar(50)  NOT NULL,
    [Password] varchar(128)  NOT NULL,
    [IsActive] bit  NOT NULL,
    [RoleId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [AppointmentId] in table 'Appointments'
ALTER TABLE [dbo].[Appointments]
ADD CONSTRAINT [PK_Appointments]
    PRIMARY KEY CLUSTERED ([AppointmentId] ASC);
GO

-- Creating primary key on [DoctorId] in table 'Doctors'
ALTER TABLE [dbo].[Doctors]
ADD CONSTRAINT [PK_Doctors]
    PRIMARY KEY CLUSTERED ([DoctorId] ASC);
GO

-- Creating primary key on [MedicineId] in table 'Medicines'
ALTER TABLE [dbo].[Medicines]
ADD CONSTRAINT [PK_Medicines]
    PRIMARY KEY CLUSTERED ([MedicineId] ASC);
GO

-- Creating primary key on [MessageId] in table 'Messages'
ALTER TABLE [dbo].[Messages]
ADD CONSTRAINT [PK_Messages]
    PRIMARY KEY CLUSTERED ([MessageId] ASC);
GO

-- Creating primary key on [RoleId] in table 'Roles'
ALTER TABLE [dbo].[Roles]
ADD CONSTRAINT [PK_Roles]
    PRIMARY KEY CLUSTERED ([RoleId] ASC);
GO

-- Creating primary key on [SpecializationId] in table 'Specializations'
ALTER TABLE [dbo].[Specializations]
ADD CONSTRAINT [PK_Specializations]
    PRIMARY KEY CLUSTERED ([SpecializationId] ASC);
GO

-- Creating primary key on [UserId] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [PatientId] in table 'Appointments'
ALTER TABLE [dbo].[Appointments]
ADD CONSTRAINT [FK_160]
    FOREIGN KEY ([PatientId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_160'
CREATE INDEX [IX_FK_160]
ON [dbo].[Appointments]
    ([PatientId]);
GO

-- Creating foreign key on [DoctorId] in table 'Appointments'
ALTER TABLE [dbo].[Appointments]
ADD CONSTRAINT [FK_169]
    FOREIGN KEY ([DoctorId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_169'
CREATE INDEX [IX_FK_169]
ON [dbo].[Appointments]
    ([DoctorId]);
GO

-- Creating foreign key on [UserId] in table 'Doctors'
ALTER TABLE [dbo].[Doctors]
ADD CONSTRAINT [FK_128]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_128'
CREATE INDEX [IX_FK_128]
ON [dbo].[Doctors]
    ([UserId]);
GO

-- Creating foreign key on [SpecializationId] in table 'Doctors'
ALTER TABLE [dbo].[Doctors]
ADD CONSTRAINT [FK_27]
    FOREIGN KEY ([SpecializationId])
    REFERENCES [dbo].[Specializations]
        ([SpecializationId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_27'
CREATE INDEX [IX_FK_27]
ON [dbo].[Doctors]
    ([SpecializationId]);
GO

-- Creating foreign key on [RecieverId] in table 'Messages'
ALTER TABLE [dbo].[Messages]
ADD CONSTRAINT [FK_163]
    FOREIGN KEY ([RecieverId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_163'
CREATE INDEX [IX_FK_163]
ON [dbo].[Messages]
    ([RecieverId]);
GO

-- Creating foreign key on [SenderId] in table 'Messages'
ALTER TABLE [dbo].[Messages]
ADD CONSTRAINT [FK_166]
    FOREIGN KEY ([SenderId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_166'
CREATE INDEX [IX_FK_166]
ON [dbo].[Messages]
    ([SenderId]);
GO

-- Creating foreign key on [RoleId] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK_153]
    FOREIGN KEY ([RoleId])
    REFERENCES [dbo].[Roles]
        ([RoleId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_153'
CREATE INDEX [IX_FK_153]
ON [dbo].[Users]
    ([RoleId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------