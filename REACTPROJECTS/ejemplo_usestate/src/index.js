import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import reportWebVitals from './reportWebVitals';
import Coche from './componentes/Car';


const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <React.StrictMode>
    <Coche marca="Audi" modelo="Q7" aceleracion="30" velocidadmaxima="230"/>
    <Coche marca="Ford" modelo="Mustang GT0" aceleracion="35" velocidadmaxima="300"/>
  </React.StrictMode>
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
