import {Component} from 'react';
import { BrowserRouter, Routes, Route } from "react-router-dom";
// import { useParams } from 'react-router-dom';


export default class RutasParametros extends Component{

    render(){
        function CollatzParamsUrl(){
            // var {numero} = useParams();

            return("a")
        }
        return(<BrowserRouter>
        <Routes>
            <Route path='/collatz/:numero' element={<CollatzParamsUrl/>}/>
        </Routes>
        </BrowserRouter>)
    }
}