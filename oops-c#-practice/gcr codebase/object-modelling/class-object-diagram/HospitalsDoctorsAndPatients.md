# Hospital, Doctors, and Patients (Association and Communication) Diagram
```mermaid
classDiagram
    class Hospital{
        +String hospitalName
        +String location
        +List~Doctor~ doctors
        +List~Patient~ patients
        +addDoctor(doctor: Doctor)
        +addPatient(patient: Patient)
    }
    class Doctor{
        +String doctorId
        +String name
        +String specialization
        +List~Patient~ currentPatients
        +consult(patient: Patient, notes: String)
        +viewConsultationHistory(patient: Patient) String
    }
    class Patient{
        +String patientId
        +String name
        +String phone
        +List~Doctor~ consultedDoctors
        +List~String~ consultationHistory
        +bookConsultation(doctor: Doctor)
    }

    Hospital o-- "*" Doctor : employs
    Hospital o-- "*" Patient : treats
    Doctor "1" -- "*" Patient : consults
    Patient "1" -- "*" Doctor : consulted by
