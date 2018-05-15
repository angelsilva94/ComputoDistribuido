<template>
  <div>
    <div class="panel panel-default" v-if="!showDir">
      <div class="panel-heading">
      <!-- <button class="btn btn-primary" @click="addDirectorio">Añadir al Directorio</button>addDirectorio -->
      <router-link
                tag="button"
                :to="{ name: 'userAdd'}"
                class="btn btn-primary"
                @click.native="addDirectorio">Añadir al Directorio</router-link>
      <button class="btn btn-danger" @click="removeDirectorio">Remover del Directorio</button>
      <button class="btn btn-danger" @click="debug">Debug</button>
      
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
        <tr v-for="(item, index) in tabla">
          <td><input type="checkbox"  :value="item.id" v-model="selectedId"></td>              
          <td>{{item.id}}</td>    
          <td>{{item.nombre}}</td>    
          <td>{{item.telefono}}</td>    
          <td>{{item.imagen}}</td>    
          <!-- {{item.id}} -->
        </tr>
          <!-- {{selectedId}} -->
        
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
      showDir:false,
      selectedId:[]
    }
  },
  methods:{
    addDirectorio: function(){
      console.log('añadir directorio');
      // !this.addDir
      this.showDir = !this.showDir;
    },
    removeDirectorio:function (){
      console.log('remove');
      console.log(JSON.stringify(this.selectedId));
      // this.selectedId.forEach((item)=>{
      //   let temp = this.tabla.map((e)=>{return e.id}).indexOf(item.id);
      //   console.log(temp)
      //   axios.delete('directorio'+this.)
      // });

      // this.selectedId.forEach((id)=>{
      //    axios.delete('/directorio/' + id).then(res=>{
      //     console.log(res);
      //     this.tabla.splice(id,1);        
      //   }).catch(error=>{
      //     console.log(error);
      //   });
      // });
      this.selectedId.forEach((item)=>{

        // console.log(index);
        axios.delete('directorio/'+ item).then(res=>{
        let index = this.tabla.map((e)=>{return e.id}).indexOf(item);
          
          this.tabla.splice(index,1);        
          console.log(res);
        }).catch(error=>{
          console.log(error)
        });

      });
    },
    debug: function(){
      // axios.get('directorio/'+this.selectedId).then(res=>{
      //   this.tabla.splice()
      //   console.log(res);
      // }).catch(error=>{
      //   console.log(error);
      // })

      // console.log(this.selectedId);
      // console.log(JSON.stringify(this.tabla));      
      // this.tabla.splice(this.selectedId,1);
    
      console.log(JSON.stringify(this.selectedId));
      this.selectedId.forEach((item)=>{
        console.log('item: '+item);
        let temp = this.tabla.map((e)=>{return e.id}).indexOf(item);
        this.tabla.splice(temp,1);
        console.log(temp)

      });
      // for(let i=0; i<this.selectedId.length; i++){
      //   let temp = this.tabla.map((e)=>{return e.id}).indexOf(this.selectedId[i]);
      //   console.log(temp);
      // }
      // console.log(temp);
        // console.log(JSON.stringify(this.tabla));
    }
  },
  created(){
    console.log('CREATED');
    axios.get('/directorio').then(res =>{
      // console.log(res);
      
      this.tabla = res.data;
     
      console.log("final: "+ JSON.stringify(this.tabla));
    }).catch(error => {
      console.log("error");
    })
  }
  
}
</script>

