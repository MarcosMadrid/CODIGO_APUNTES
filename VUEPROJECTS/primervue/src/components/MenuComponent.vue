<template>
    <nav class="navbar navbar-expand-lg bg-body-tertiary">
        <div class="container-fluid">
            <router-link class="navbar-brand" to="/">HOME</router-link>
            <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarNav">
            <ul class="navbar-nav">
                <li class="nav-item">
                    <router-link class="nav-link" to="/HelloWorld">HELLOW_WORLD</router-link>
                </li>
                <li class="nav-item">
                    <router-link class="nav-link" to="/HolaMundo">HOLA MUNDO</router-link>      
                </li>
                <li class="nav-item">
                    <router-link class="nav-link" to="/hooks">HOOKS</router-link>
                </li>
                <li class="nav-item">
                    <router-link class="nav-link" to="/MirarNumero">MirarNumero</router-link>
                </li>
                <li class="nav-item">
                    <router-link class="nav-link" to="/PropiedadConmutada">PropiedadConmutada</router-link>
                </li>
            </ul>
            </div>
        </div>
    </nav>
</template>

<script>
export default {
    name : 'MenuComponent'
}
</script>

<style>
ul li{
    display: inline;
}
li{
    margin: 5px;
}
</style>