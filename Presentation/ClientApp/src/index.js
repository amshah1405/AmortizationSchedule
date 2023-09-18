import 'bootstrap/dist/css/bootstrap.css';
import React from 'react'; 
import ReactDom from 'react-dom';  
import App from './App';
import { BrowserRouter } from 'react-router-dom'; 


const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');
const root = ReactDom.createRoot(document.getElementById("root"));
root.render(
    <div> 
        
        <BrowserRouter basename={baseUrl}>
            <App />
        </BrowserRouter>);
    </div>
) 