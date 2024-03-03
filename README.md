<h1 align="center">Hi 👋, I'm Sherif Nagaty</h1>
<h3 align="center">A passionate Full-Stack developer from Egypt</h3>

- 🔭 I’m currently working on [Hospital System API](https://github.com/Sherifwaelnagaty)

- 👨‍💻 All of my projects are available at [https://github.com/Sherifwaelnagaty](https://github.com/Sherifwaelnagaty)

- 📫 How to reach me **Sherifwael0@gmail.com**

- 📄 Know about my experiences [https://drive.google.com/file/d/1Sn6s1sTU9nVWiE5Dt8LYnIwjGupDsUTM/view?usp=sharing](https://drive.google.com/file/d/1Sn6s1sTU9nVWiE5Dt8LYnIwjGupDsUTM/view?usp=sharing)

<h3 align="left">Connect with me:</h3>
<p align="left">
<a href="https://twitter.com/sherifnagaty3" target="blank"><img align="center" src="https://raw.githubusercontent.com/rahuldkjain/github-profile-readme-generator/master/src/images/icons/Social/twitter.svg" alt="sherifnagaty3" height="30" width="40" /></a>
<a href="https://linkedin.com/in/sherif-wael" target="blank"><img align="center" src="https://raw.githubusercontent.com/rahuldkjain/github-profile-readme-generator/master/src/images/icons/Social/linked-in-alt.svg" alt="sherif-wael" height="30" width="40" /></a>
</p>

<h3 align="left">Languages and Tools:</h3>
<p align="left"> <a href="https://www.w3schools.com/cs/" target="_blank" rel="noreferrer"> <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/csharp/csharp-original.svg" alt="csharp" width="40" height="40"/> </a> <a href="https://dotnet.microsoft.com/" target="_blank" rel="noreferrer"> <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/dot-net/dot-net-original-wordmark.svg" alt="dotnet" width="40" height="40"/> </a> <a href="https://git-scm.com/" target="_blank" rel="noreferrer"> <img src="https://www.vectorlogo.zone/logos/git-scm/git-scm-icon.svg" alt="git" width="40" height="40"/> </a> <a href="https://www.microsoft.com/en-us/sql-server" target="_blank" rel="noreferrer"> <img src="https://www.svgrepo.com/show/303229/microsoft-sql-server-logo.svg" alt="mssql" width="40" height="40"/> </a> <a href="https://postman.com" target="_blank" rel="noreferrer"> <img src="https://www.vectorlogo.zone/logos/getpostman/getpostman-icon.svg" alt="postman" width="40" height="40"/> </a> </p>
# Hospital System API Documentation

## Introduction

Welcome to the Hospital System API documentation! This API provides functionalities for managing doctors, patients, coupons, user registration and login, as well as booking and canceling doctor appointments.

## Base URL

The base URL for the API is `https://api.hospitalsystem.com`.

## Authentication

Some endpoints require authentication. You need to include the authentication token in the request headers. To obtain a token, you must register and log in using the provided endpoints.

## Endpoints

### Doctors

#### 1. Get All Doctors

- **Endpoint:** `/doctors`
- **Method:** `GET`
- **Description:** Retrieve a list of all doctors.
- **Authentication:** Required

#### 2. Get Doctor by ID

- **Endpoint:** `/doctors/{doctorId}`
- **Method:** `GET`
- **Description:** Retrieve details of a specific doctor by ID.
- **Authentication:** Required

#### 3. Add Doctor

- **Endpoint:** `/doctors`
- **Method:** `POST`
- **Description:** Add a new doctor to the system.
- **Authentication:** Required

#### 4. Edit Doctor

- **Endpoint:** `/doctors/{doctorId}`
- **Method:** `PUT`
- **Description:** Update details of a specific doctor by ID.
- **Authentication:** Required

#### 5. Delete Doctor

- **Endpoint:** `/doctors/{doctorId}`
- **Method:** `DELETE`
- **Description:** Delete a doctor from the system by ID.
- **Authentication:** Required

### Patients

#### 6. Get All Patients

- **Endpoint:** `/patients`
- **Method:** `GET`
- **Description:** Retrieve a list of all patients.
- **Authentication:** Required

#### 7. Get Patient by ID

- **Endpoint:** `/patients/{patientId}`
- **Method:** `GET`
- **Description:** Retrieve details of a specific patient by ID.
- **Authentication:** Required

### Coupons

#### 8. Add Coupon

- **Endpoint:** `/coupons`
- **Method:** `POST`
- **Description:** Add a new coupon to the system.
- **Authentication:** Required

#### 9. Update Coupon

- **Endpoint:** `/coupons/{couponId}`
- **Method:** `PUT`
- **Description:** Update details of a specific coupon by ID.
- **Authentication:** Required

#### 10. Delete Coupon

- **Endpoint:** `/coupons/{couponId}`
- **Method:** `DELETE`
- **Description:** Delete a coupon from the system by ID.
- **Authentication:** Required

#### 11. Deactivate Coupon

- **Endpoint:** `/coupons/deactivate/{couponId}`
- **Method:** `PUT`
- **Description:** Deactivate a coupon by ID.
- **Authentication:** Required

### User Management

#### 12. Register User

- **Endpoint:** `/users/register`
- **Method:** `POST`
- **Description:** Register a new user in the system.

#### 13. Login User

- **Endpoint:** `/users/login`
- **Method:** `POST`
- **Description:** Log in a user and obtain an authentication token.

### Appointments

#### 14. Book Doctor

- **Endpoint:** `/appointments/book`
- **Method:** `POST`
- **Description:** Book an appointment with a doctor.
- **Authentication:** Required

#### 15. Cancel Doctor

- **Endpoint:** `/appointments/cancel/{appointmentId}`
- **Method:** `PUT`
- **Description:** Cancel a booked appointment by ID.
- **Authentication:** Required

## Conclusion

This API documentation covers the essential endpoints for managing doctors, patients, coupons, user registration and login, as well as booking and canceling doctor appointments. Please ensure proper authentication for endpoints that require it. If you have any questions or issues, feel free to contact our support team.
