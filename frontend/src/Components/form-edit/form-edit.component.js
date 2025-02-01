import React, { useState } from "react";
import { createForm, updateForm } from "../../Services/Apis";

const FormEdit = ({ formId }) => {
  const [formName, setFormName] = useState("");
  const [formDescription, setFormDesciption] = useState("");

  const handleSave = async () => {
    const formData = { nombre: formName , descripcion: formDescription};

    try {
      if (formId) {
        await updateForm(formId, formData);
        alert("Formulario actualizado correctamente");
      } else {
        await createForm(formData);
        alert("Formulario creado correctamente");
      }
    } catch (error) {
      console.error("Error saving form:", error);
    }
  };

  return (
    <div>
      <h2>{formId ? "Editar Formulario" : "Crear Formulario"}</h2>
      <input
        type="text"
        value={formName}
        onChange={(e) => setFormName(e.target.value)}
        placeholder="Nombre del formulario"
      />
      <input
        type="text"
        value={formDescription}
        onChange={(e) => setFormDesciption(e.target.value)}
        placeholder="Descripción del formulario"
      />
      <button onClick={handleSave}>Guardar</button>
    </div>
  );
};

export default FormEdit;