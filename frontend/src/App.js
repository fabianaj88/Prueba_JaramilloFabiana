
import React, { useState } from "react";
import FormList from "./Components/form-list/form-list.component";
import FormEdit from "./Components/form-edit/form-edit.component";
import FormInputList from "./Components/form-input-list/form-input-list.component";
import FormInputEdit from "./Components/form-input-edit/form-input-edit.component";
import "./App.css"; 

const App = () => {
  const [activeComponent, setActiveComponent] = useState("form-list"); 

  return (
    <div className="app-container">
      <h1>Administrador de Formularios</h1>

     
      <nav className="menu">
        <button
          className={activeComponent === "form-list" ? "active" : ""}
          onClick={() => setActiveComponent("form-list")}
        >
          Lista de Formularios
        </button>
        <button
          className={activeComponent === "form-edit" ? "active" : ""}
          onClick={() => setActiveComponent("form-edit")}
        >
          Crear/Editar Formulario
        </button>
        <button
          className={activeComponent === "form-input-list" ? "active" : ""}
          onClick={() => setActiveComponent("form-input-list")}
        >
          Lista de Inputs
        </button>
        <button
          className={activeComponent === "form-input-edit" ? "active" : ""}
          onClick={() => setActiveComponent("form-input-edit")}
        >
          Crear/Editar Input
        </button>
      </nav>

      <div className="content">
        {activeComponent === "form-list" && <FormList />}
        {activeComponent === "form-edit" && <FormEdit />}
        {activeComponent === "form-input-list" && <FormInputList formId={1} />}
        {activeComponent === "form-input-edit" && <FormInputEdit formId={1} />}
      </div>
    </div>
  );
};


export default App;