# PyGold

A Python-like programming language with distinct syntax differences, designed specifically for GUI application development using GOLD Parser.

## Overview

PyGold is a modern programming language that combines the ease of use found in Python with a unique syntax that makes GUI development more intuitive. Built with GOLD Parser, PyGold offers a clean and readable approach to creating graphical user interfaces while maintaining powerful programming constructs.

## Features

- **Python-inspired functionality** with distinctive syntax improvements
- **Specialized for GUI application development**
- **Clear variable declarations** using `let` keyword and `:=` assignment operator
- **Block-based structure** with explicit `begin` and `end` keywords instead of indentation
- **Strong type support** with function return type declarations
- **Comprehensive control structures** including `if`/`elif`/`else`, `while`, `for`, and `until` loops
- **Object-oriented programming** with class definitions and methods
- **Exception handling** with `try`/`except`/`finally` blocks

## Syntax Highlights

### Variable Declaration and Assignment
```
let x := 10            # Declare and initialize a variable
y := x * 5             # Assignment to an existing variable
```

### Control Structures
```
if x > 10 begin
    print("x is greater than 10")
end
elif x == 10 begin
    print("x is exactly 10")
end
else begin
    print("x is less than 10")
end
```

### Loops
```
# While loop
while counter < 10 begin
    counter := counter + 1
end

# For loop
for item in items begin
    print(item)
end

# Until loop (not available in Python)
until counter >= 10 begin
    counter := counter + 1
end
```

### Functions
```
function calculateArea(width, height) -> int begin
    return width * height
end
```

### Classes
```
class Button begin
    let width := 100
    let height := 50
    
    function onClick() begin
        print("Button clicked!")
    end
    
    function resize(w, h) begin
        width := w
        height := h
    end
end
```

## Basic GUI Example
```
import GUI

function main() begin
    let window := GUI.Window("PyGold Demo", 800, 600)
    let button := GUI.Button("Click Me", 100, 50)
    
    button.onClick := function() begin
        GUI.MessageBox("Hello World!", "Message")
    end
    
    window.add(button, 350, 275)
    window.show()
end

main()
```

## Installation

1. Clone the PyGold repository:
   ```
   git clone https://github.com/yourusername/pygold.git
   cd pygold
   ```

2. Install dependencies:
   ```
   pip install -r requirements.txt
   ```

3. Build the parser:
   ```
   python build_parser.py
   ```

## Usage

Run a PyGold script:
```
pygold script.pg
```

## Requirements

- Python 3.7+
- GOLD Parser Engine
- Required Python packages (see requirements.txt)

## Development Status

PyGold is currently in development. Feedback and contributions are welcome!

## License

[Insert your preferred license here]

## Author

Created by Hanin

## Contributing

Interested in contributing to PyGold? Check out our [contribution guidelines](CONTRIBUTING.md).
