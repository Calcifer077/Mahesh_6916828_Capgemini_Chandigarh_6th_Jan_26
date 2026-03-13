create database HospitalDB;

use HospitalDB;

CREATE TABLE Patients (
    PatientId INT PRIMARY KEY,
    FullName VARCHAR(100),
    DateOfBirth DATE,
    ContactNumber VARCHAR(15)
);

CREATE TABLE Doctors (
    DoctorId INT PRIMARY KEY,
    Name VARCHAR(100),
    Specialization VARCHAR(100)
);

CREATE TABLE Appointments (
    AppointmentId INT PRIMARY KEY,
    PatientId INT,
    DoctorId INT,
    AppointmentDate DATETIME,
    Remarks VARCHAR(255),
    
    FOREIGN KEY (PatientId) REFERENCES Patients(PatientId),
    FOREIGN KEY (DoctorId) REFERENCES Doctors(DoctorId)
);

