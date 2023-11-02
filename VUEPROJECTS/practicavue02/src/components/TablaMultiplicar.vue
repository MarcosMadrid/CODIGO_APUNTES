<template>
    <div>
        <input v-model="numero">
        <h2>Method HTML</h2>
        <div id="container_method_html" >
            <table v-html="GenerarTablaMethod()" class="table"></table>
        </div>

        <h2>Directivas HTML</h2>
        <div id="container_directivas_html">
            <table class="table">  
                <tbody>
                    <tr v-for="(void_e,index) in  Array(11)" :key="index">
                        <td>
                            {{ this.numero }} * {{ index }}
                        </td>
                        <td>
                            {{ this.numero * index }}
                        </td>
                    </tr>                              
                </tbody>
            </table>
        </div>

        <h2>Directivas Global Filters Operation</h2>
        <div id="container_method_html">
            <table class="table">  
                <tbody>
                    <tr v-for="(void_e,index) in  Array(11)" :key="index">
                        <td>
                            {{ this.numero }} * {{ index }}
                        </td>
                        <td>
                            {{ $filters.Multiplicar(this.numero, index) }}
                        </td>
                    </tr>                              
                </tbody>
            </table>
        </div>
        
    </div>

</template>

<script>

export default {
    name: 'TablaMultiplicar',
    data (){
        return{
            numero: null
        }
    },
    methods:{
        GenerarTablaMethod(){                                 
            var tbody = document.createElement('tbody');            

            for (let index = 0; index <= 10; index++) {
                var row = document.createElement('tr');

                row.insertCell(0);
                row.cells[0].textContent = this.numero + "*" + index;

                row.insertCell(-1);
                row.cells[1].textContent = this.numero * index;             
                            
                tbody.appendChild(row);                
            }            

            return tbody.innerHTML;
        },
    }
}
</script>

<style>

</style>