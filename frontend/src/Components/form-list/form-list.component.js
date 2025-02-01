import React, { useEffect, useState } from "react";
import { getForms } from "../../Services/Apis";
import FormInputEdit from "../form-input-edit/form-input-edit.component";

const FormList = () => {
  const [forms, setForms] = useState([]);
  const [selectedFormId, setSelectedFormId] = useState(null);

  useEffect(() => {
    const fetchForms = async () => {
      try {
        const formsData = await getForms();
        setForms(formsData);
      } catch (error) {
        console.error("Error fetching forms:", error);
      }
    };

    fetchForms();
  }, []);
  
  return (

  <div>
      {!selectedFormId ? (
        // Mostrar lista de formularios
        <div>
          <h2>Lista de Formularios</h2>
          {forms.map((form) => (
            <button 
              key={form.id}
              onClick={() => setSelectedFormId(form.id)} // Establecemos el formId seleccionado
            >
              {form.nombre}
            </button>
          ))}
        </div>
      ) : (
        // Mostrar componente de edición
        <FormInputEdit 
          formId={selectedFormId}
          onClose={() => setSelectedFormId(null)} // Función para volver
        />
      )}
    </div>
  );
};

export default FormList;