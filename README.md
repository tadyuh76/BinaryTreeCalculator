# Binary Tree Calculator

A **C# WinForms-based calculator** that evaluates mathematical expressions using a binary tree structure. This project demonstrates the practical application of binary trees in parsing and evaluating arithmetic expressions efficiently.

## ✨ Features

- **Supported Operators**: Addition (`+`), subtraction (`-`), multiplication (`*`), division (`/`), power (`^`), and square root (`√`).
- **Parentheses Support**: Accurately evaluates nested expressions with parentheses.
- **Floating-Point Arithmetic**: Supports decimal values for precise calculations.
- **Interactive Interface**: A user-friendly interface with clickable buttons to input expressions.
- **Custom Rounded Buttons**: Stylish, rounded buttons for a modern look and feel.
- **Responsive UI**: Button background color lightens when hovered for better user interaction.
- **Expression Editing**: 
  - **AC**: Clears the entire expression.
  - **Del**: Deletes the last character from the expression.
  - **Caret Movement**: Allows moving the caret left or right in the expression for easier editing.
- **Error Handling**: Provides feedback for invalid expressions or division by zero.


## 🖼️ Demo
![image](https://github.com/user-attachments/assets/85ec1116-699a-4b00-a8da-1569fc559202)

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
   git clone https://github.com/tadyuh76/BinaryTreeCalculator.git
2. Open the solution file `BinaryTreeCalculator.sln` in Visual Studio.

3. Run the application: Press `F5`.

## 📝 Usage

1. Enter a mathematical expression using the on-screen buttons or keyboard.
2. Click the `=` button to evaluate the expression.
3. Use `AC` to clear the expression or `Del` to delete the last character.


## 💡 Example Expressions

| Expression       | Result |
|------------------|--------|
| `3 + 5`          | `8`    |
| `(2 + 3) * 4`    | `20`   |
| `10 / (5 - 3)`   | `5`    |
| `2.5 * 4`        | `10`   |
