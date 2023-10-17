import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import reportWebVitals from './reportWebVitals';
// import Contador from './components/Class_contador';
// import App from './components/App/App';
// import SumarNumeros from './components/SumarNumeros/SumarNumeros';
// import SaludoPadre from './components/SaludoPadre';
// import PadreMatematicas from './components/PadreMatematicas';
// import Car from './components/Car';
import DibujosComplejos from './components/DibujosComplejos';

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <React.StrictMode> 
    <DibujosComplejos></DibujosComplejos>
  </React.StrictMode>
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
