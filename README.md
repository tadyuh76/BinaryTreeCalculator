# Binary Tree Calculator

A **C# WinForms-based calculator** that evaluates mathematical expressions using a binary tree structure. This project showcases the practical application of binary trees in parsing and evaluating arithmetic expressions efficiently.

## ✨ Features

- **Supported Operators**: Addition (`+`), subtraction (`-`), multiplication (`*`), and division (`/`).
- **Parentheses Support**: Evaluates nested expressions with parentheses accurately.
- **Floating-Point Arithmetic**: Supports decimal values for precise calculations.
- **User-Friendly Functions**:
  - **AC**: Clears the entire expression.
  - **Del**: Deletes the last character in the expression.
- **Error Handling**: Provides feedback for invalid expressions or division by zero.

## 🖼️ Demo
![image](https://github.com/user-attachments/assets/b2ac0e7b-d7b2-42b7-8d87-d061022aa211)


## 🛠️ How It Works

The calculator uses a **binary tree** for parsing and evaluating mathematical expressions. Here's the step-by-step process:

1. **Tokenization**: Breaks down the input into numbers, operators, and parentheses.
2. **Conversion**: Converts the infix expression into postfix (Reverse Polish Notation).
3. **Tree Construction**: Builds a binary tree from the postfix expression.
4. **Evaluation**: Recursively evaluates the binary tree to calculate the result.

## 🚀 Getting Started

Follow these instructions to set up and run the project on your local machine.

### Prerequisites

- [Visual Studio](https://visualstudio.microsoft.com/) (with `.NET desktop development` workload installed)
- .NET Framework **4.7.2** or higher

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/BinaryTreeCalculator.git
2. Open the solution file `BinaryTreeCalculator.sln` in Visual Studio.

3. Build the project:
   - Press `Ctrl + Shift + B`.

4. Run the application:
   - Press `F5`.

## 📝 Usage

1. Enter a mathematical expression using the on-screen buttons or keyboard.
2. Click the `=` button to evaluate the expression.
3. Use `AC` to clear the expression or `Del` to delete the last character.

## 📂 Project Structure

- **`MainForm.cs`**: Contains the main logic for UI interaction and expression evaluation.
- **`MainForm.Designer.cs`**: Auto-generated code for the calculator's graphical interface.
- **`Node.cs`**: Defines the structure and functionality of binary tree nodes used in evaluation.

## 💡 Example Expressions

| Expression       | Result |
|------------------|--------|
| `3 + 5`          | `8`    |
| `(2 + 3) * 4`    | `20`   |
| `10 / (5 - 3)`   | `5`    |
| `2.5 * 4`        | `10`   |
