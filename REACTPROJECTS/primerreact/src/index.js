import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import reportWebVitals from './reportWebVitals';
import Saludo from './componentes/Saludo';
import Metodos from './componentes/Metodos';

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <React.StrictMode>
    <Metodos></Metodos>
    <Saludo nombre="Lucia" edad="40"></Saludo>
    <Saludo nombre="Paco" edad="23"></Saludo>
  </React.StrictMode>
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
