# 🚲 Bicycle Rental & 🍄 Mushroom Identifier
### Lab 1 - C# Windows Forms (GUI) Project

**Student Name:** Mucyo Billy  
**Student Number:** 26853  
**Course:** C# Programming  

---

## 📖 About This Project
This is a **C# Windows Forms (WinForms) Application** developed for Lab 1. It demonstrates the practical use of **variables, operators, decision control statements (if/switch), and repetition statements (loops)** within a Graphical User Interface (GUI). 

Instead of a standard console, the application features interactive windows with clickable buttons and text boxes, matching the provided UI flowchart.

---

## ✨ Features

### 🔐 1. Login Form
* A secure graphical entry point requiring a username and password.
* Validates user input via a "Login" button before granting access to the main menu.

### 📋 2. Interactive Main Menu Form
* A central hub allowing users to navigate between the two mini-projects using clickable buttons.
* Includes a "Logout" button to safely close the application.

### 🚲 3. Problem 1: Bicycle Rental Calculator Form
* **Input:** Text boxes to accept integer start and end times (24-hour format).
* **Validation:** Ensures start time is less than end time and within valid ranges (0-24).
* **Tiered Pricing Logic:**
  * **500 RWF/hr:** 00:00 - 07:00 and 21:00 - 24:00
  * **1000 RWF/hr:** 07:00 - 14:00 and 19:00 - 21:00
  * **1500 RWF/hr:** 14:00 - 19:00
* **Output:** A "Calculate Total" button that dynamically displays the total hours and final cost on the form.

### 🍄 4. Problem 2: Mushroom Identifier Game Form
* **Goal:** Identifies one of 6 specific mushroom types based on user interaction.
* **Logic:** Uses an elimination algorithm based on biological traits (gills/pores, habitat, ring, convex cup).
* **Interaction:** "Yes" and "No" buttons that dynamically update the question label on the screen.
* **Efficiency:** Asks a maximum of 3 to 4 questions to accurately deduce the mushroom and displays the result directly on the form.

---

## 🛠️ Tech Stack
* **Language:** C#
* **Framework:** .NET 6.0 (Windows)
* **UI Technology:** Windows Forms (WinForms)
* **Environment:** Visual Studio

---

## 🚀 How to Run
1. Clone or download this repository to your local Windows machine.
2. Open Visual Studio.
3. Open the **`26853_Mucyo_Billy.csproj`** file.
4. Press **`F5`** or click the **Start** button to launch the graphical interface.

---

## 📂 Project Structure
```text
26853_Mucyo_Billy/
├── 26853_Mucyo_Billy.csproj  # .NET Windows Forms project configuration
├── Program.cs                # Main C# source code containing all Forms and logic
└── README.md                 # Project documentation (this file)
