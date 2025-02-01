import axios from "axios";

const API_BASE_URL = "https://localhost:7187/api"; 

// Funciones relacionadas con formularios
export const getForms = async () => {
  try {
    const response = await axios.get(`${API_BASE_URL}/Formularios`);
    
    return response.data.$values;
    
  } catch (error) {
    console.error("Error fetching forms:", error);
    throw error;
  }
};

export const createForm = async (formData) => {
  try {
    console.log("**************",formData)
    const response = await axios.post(`${API_BASE_URL}/Formularios`, formData);
    console.log("**************",response)
    
    return response.data;
    
  } catch (error) {
    console.error("Error creating form:", error);
    throw error;
  }
};

export const updateForm = async (formId, formData) => {
  try {
    const response = await axios.put(`${API_BASE_URL}/forms/${formId}`, formData);
    return response.data;
  } catch (error) {
    console.error("Error updating form:", error);
    throw error;
  }
};

export const deleteForm = async (formId) => {
  try {
    const response = await axios.delete(`${API_BASE_URL}/forms/${formId}`);
    return response.data;
  } catch (error) {
    console.error("Error deleting form:", error);
    throw error;
  }
};

// Funciones relacionadas con inputs (campos)
export const getInputs = async (formId) => {
  try {
    
    const response = await axios.get(`${API_BASE_URL}/Campos/formulario/${formId}`);
    console.log("**************",response)
    
    return response.data.$values;
  } catch (error) {
    console.error("Error fetching inputs:", error);
    throw error;
  }
};

export const createInput = async (inputData) => {
  try {
    console.log("**************",inputData)
    const response = await axios.post(`${API_BASE_URL}/Campos`, inputData);
    return response.data;
  } catch (error) {
    console.error("Error creating input:", error);
    throw error;
  }
};

export const updateInput = async (inputId, inputData) => {
  try {
    console.log("*******",inputData)
    const response = await axios.put(`${API_BASE_URL}/Campos/${inputId}`, inputData, {
      headers: {
        'Content-Type': 'application/json'
      }
    });
    console.log(response)
    return response.data;
  } catch (error) {
    console.error("Error updating input:", error);
    throw error;
  }
};

export const deleteInput = async (inputId) => {
  try {
    const response = await axios.delete(`${API_BASE_URL}/Campos/${inputId}`);
    return response.data;
  } catch (error) {
    console.error("Error deleting input:", error);
    throw error;
  }
};