# CedarBoard Documentation

## 1. Overview
CedarBoard is a tree structure editor built with WPF. Users can arrange textboxes with parent-child relationships and automatically connect them with lines. It is particularly suitable for idea organization and concept visualization.
---
### Key Features
- Intuitive tree structure editing
- Automatic node connections
- Modern WPF-based UI
- User-customizable interface
- Manage multiple projects within a single workspace

## 2. Installation
### Requirements
- Windows 10 or later
- .NET 6.0 or higher
- Visual Studio 2022 (recommended)

### Build Instructions
1. Clone the repository
   ```sh
   git clone https://github.com/kyonsy/CedarBoard.git
   cd CedarBoard
   
## 3. Usage
### Home Screen Functions
- **Create New Project:** Start a new tree structure  
- **Open Existing Project:** Load saved projects  
- **Workspace Management:** Handle multiple projects in one workspace  
- **Settings:** Customize application behavior  

### Creating Nodes
1. Right-click on the canvas and select "Create New Node"  
2. Enter text and confirm  

### Connecting Nodes
- Child nodes are **automatically connected** when created under a selected parent node  
- Drag nodes to reposition them  

### Other Operations
- **Delete Node:** Right-click a node and select "Delete"  
- **Edit Node:** Double-click a node to modify its text  

## 4. Customization
### Configuration
- Modify UI and behavior by editing `App.config` or `Settings.xaml`  

### Code Extensions
- Customize node UI in `NodeControl.xaml`  
- Adjust connection logic in `GraphManager.cs`  

## 5. License & Contribution
### License
- This project is licensed under the **MIT License**.  

### Contributing
1. Create an Issue to report bugs or suggest improvements  
2. Fork the repository and submit a Pull Request  
3. Help improve documentation or add new features  
