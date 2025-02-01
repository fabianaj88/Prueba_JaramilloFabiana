import React, { useEffect, useState } from "react";
import { getInputs,deleteInput} from "../../Services/Apis";
import '../../App.css';
import FormInputEdit from "../form-input-edit/form-input-edit.component";

const FormInputList = ({ formId }) => {
  const [inputs, setInputs] = useState([]);
  const [showModal, setShowModal] = useState(false);
  const [selectedInputId, setSelectedInputId] = useState(null);

  const fetchInputs = async () => {
    if (formId) {
      try {
        const inputsData = await getInputs(formId);
        setInputs(inputsData);
      } catch (error) {
        console.error("Error fetching inputs:", error);
      }
    }
  };

  useEffect(() => {
    fetchInputs();
  }, [formId]);

  const handleEdit = (input) => {
    setSelectedInputId(input.id);
    setShowModal(true);
  };

  const handleCloseModal = () => {
    setShowModal(false);
    setSelectedInputId(null);
    // Recargar la lista después de cerrar el modal
    fetchInputs();
  };

  const handleDelete = async (input) => {
    if (window.confirm('¿Estás seguro de que deseas eliminar este input?')) {
      try {
        await deleteInput(input.id);
        fetchInputs();
        alert('Input eliminado exitosamente');
      } catch (error) {
        console.error("Error al eliminar:", error);
        alert('Error al eliminar el input');
      }
    }
  };

  return (
    <div className="input-list-container">
      <h2>Inputs del Formulario</h2>
      <table className="custom-table">
        <thead>
          <tr>
            <th>Nombre</th>
            <th>Tipo</th>
            <th>Acciones</th>
          </tr>
        </thead>
        <tbody>
          {inputs.map((input) => (
            <tr key={input.id}>
              <td>{input.nombre}</td>
              <td>{input.tipo}</td>
              <td className="action-column">
                <button 
                  className="btn edit-btn" 
                  onClick={() => handleEdit(input)}
                >
                  Editar
                </button>
                <button 
                  className="btn delete-btn" 
                  onClick={() => handleDelete(input)}
                >
                  Eliminar
                </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>

      {showModal && (
        <div className="modal">
          <div className="modal-content">
            <span className="close-button" onClick={handleCloseModal}>&times;</span>
            <FormInputEdit 
              formId={formId} 
              inputId={selectedInputId}
            />
          </div>
        </div>
      )}
    </div>
  );
};

export default FormInputList;