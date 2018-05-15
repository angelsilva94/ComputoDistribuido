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
  <input id="textinput" name="textinput" placeholder="Nombre" class="form-control input-md" type="text">
  </div>
</div>

<!-- Text input-->
<div class="form-group">
  <label class="col-md-4 control-label" for="textinput">Telefono</label>  
  <div class="col-md-4">
  <input id="textinput" name="textinput" placeholder="Telefono" class="form-control input-md" type="text">
  </div>
</div>

<!-- File Button --> 
<div class="form-group">
  <label class="col-md-4 control-label" for="filebutton">Imagen</label>
  <div class="col-md-4">
    <input id="filebutton" name="filebutton" class="input-file" type="file">
  </div>
</div>

<!-- Button (Double) -->
<div class="form-group">
  <label class="col-md-4 control-label" for="button1id">Guardar Cambios?</label>
  <div class="col-md-8">
    <button id="button1id" name="button1id" class="btn btn-success">Si</button>
    <button id="button2id" name="button2id" class="btn btn-danger">No</button>
  </div>
</div>

</fieldset>
</form>

  </div>
</template>

<script>
export default {
  created(){
      console.log("nuevoa viso");
  },
  data(){
      return {
          directorio:  {
            nombre: '',
            telefono: '',
            imagen: boolean
    }
      }
  }
}
</script>

