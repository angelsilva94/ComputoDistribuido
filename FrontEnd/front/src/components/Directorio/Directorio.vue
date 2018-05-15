<template>
  <div>
    <div class="panel panel-default" v-if="!addDir">
      <div class="panel-heading">
      <!-- <button class="btn btn-primary" @click="addDirectorio">Añadir al Directorio</button>addDirectorio -->
      <router-link
                tag="button"
                :to="{ name: 'userAdd'}"
                class="btn btn-primary"
                @click.native="addDirectorio">Añadir al Directorio</router-link>
      <button class="btn btn-danger" @click="removeDirectorio">Remover del Directorio</button>
    </div>
    <!-- Table -->
    <table class="table">
      <thead>
        <tr>
          <th></th>
          <th>Id Aviso</th>
          <th>Nombre</th>
          <th>Telefono</th>
          <th>Imagen (opcional)</th>
      </tr>
      </thead>
      <tbody>
        <tr v-for="item in tabla">
          <td><input type="checkbox"  :value="item.id"></td>              
          <td>{{item.id}}</td>    
          <td>{{item.nombre}}</td>    
          <td>{{item.telefono}}</td>    
          <td>{{item.imagen}}</td>    
        </tr>
      </tbody>
      <ul></ul>
    </table>

  </div>
  <router-view></router-view>
  </div>
  
</template>

<script>
import axios from 'axios';
export default {
  data(){
    return {
      tabla : {
      },
      addDir:false
    }
  },
  methods:{
    addDirectorio: function(){
      console.log('añadir directorio');
      // !this.addDir
      this.addDir = !this.addDir;
    },
    removeDirectorio:function (){
      console.log('remove');
    }
  },
  created(){
    console.log('CREATED');
    axios.get('http://192.168.88.142:5000/api/directorio').then(res =>{
      // console.log(res);
      
      this.tabla = res.data;
     
      console.log("final: "+ JSON.stringify(this.tabla));
    }).catch(error => {
      console.log(error);
    })
  }
  
}
</script>

