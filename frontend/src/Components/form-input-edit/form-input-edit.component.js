import React, { useState } from "react";
import { createInput, updateInput } from "../../Services/Apis";

const FormInputEdit = ({ formId, inputId }) => {
  const [label, setLabel] = useState("");
  const [type, setType] = useState("text");

  const handleSave = async () => {
    const inputData = { ...(inputId && { id: inputId }),formularioId: formId, nombre: label, tipo: type};

    try {
      if (inputId) {
        await updateInput(inputId, inputData);
      } else {
        await createInput(inputData);
      }
      alert("Guardado exitoso!");
      
    } catch (error) {
      console.error("Error saving input:", error);
    }
  };

  return (
    <div>
      <h2>Crear / Editar Inputs {formId}</h2>
      <input
        type="text"
        value={label}
        onChange={(e) => setLabel(e.target.value)}
        placeholder="Label del input"
      />
      <select value={type} onChange={(e) => setType(e.target.value)}>
        <option value="text">Texto</option>
        <option value="number">Número</option>
        <option value="date">Fecha</option>
      </select>
      
      <div style={{ marginTop: "1rem" }}>
        <button onClick={handleSave}>Guardar</button>
      </div>
    </div>
  );
};

export default FormInputEdit;