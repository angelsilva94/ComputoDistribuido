<template>
  <div>
      <form class="form-horizontal">
<fieldset>

<!-- Form Name -->
<legend class="text-center">Nuevo Directorio</legend>

<!-- Text input-->
<div class="form-group">
  <label class="col-md-4 control-label" for="textinput">Nombre</label>  
  <div class="col-md-4">
  <input id="textinput" name="textinput" placeholder="Nombre" class="form-control input-md" type="text" v-model="directorio.nombre">
  </div>
</div>

<!-- Text input-->
<div class="form-group">
  <label class="col-md-4 control-label" for="textinput">Telefono</label>  
  <div class="col-md-4">
  <input id="textinput" name="textinput" placeholder="Telefono" class="form-control input-md" type="text" v-model="directorio.telefono">
  </div>
</div>

<!-- File Button --> 
<div class="form-group">
  <label class="col-md-4 control-label" for="filebutton">Imagen</label>
  <div class="col-md-4">
    <input id="filebutton" name="filebutton" class="input-file" type="file" @change="tieneArchivo">
  </div>
</div>

<!-- Button (Double) -->
<div class="form-group">
  <label class="col-md-4 control-label" for="button1id">Guardar Cambios?</label>
  <div class="col-md-8">
    <button id="button1id" name="button1id" class="btn btn-success" @click.prevent="guardar">Si</button>
    <button id="button2id" name="button2id" class="btn btn-danger" @click.prevent="cancelar">No</button>
  </div>
</div>

</fieldset>
</form>

  <hr>

  {{directorio||json}}

  </div>
</template>

<script>
import axios from 'axios';
export default {
  created(){
      console.log("nuevoa viso");
  },
  data(){
    return {
      directorio:  {
        nombre: '',
        telefono: '',
        imagen: false
      }
    }
  },
  methods:{
    guardar: function() {
      console.log(JSON.stringify(this.directorio));
      axios.post('/directorio',this.directorio).then(res=>{
          console.log(res);
          this.$router.push({ name: 'directorio' });
      }).catch(error=>{
        console.log(error);
      });
    },
    cancelar: function(){
      console.log('CANCELAR');
    },
    tieneArchivo:function(){
      console.log('ARCHIVO');
      this.directorio.imagen = true;
    }
  }
}
</script>

