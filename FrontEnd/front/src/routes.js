import Directorio from './components//Directorio/Directorio.vue'
import Principal from './components/Principal.vue'
import Avisos from './components//Avisos/Avisos.vue'
import AvisoEdit from './components//Avisos/AvisoEdit.vue'
import AvisoNuevo from './components//Avisos/AvisoNuevo.vue'
import AvisoDetalle from './components//Avisos/AvisoDetalle.vue'
import DirectorioEdit from './components//Directorio/DirectorioEdit.vue'
import DirectorioDetalle from './components//Directorio/DirectorioDetalle.vue'
import DirectorioNuevo from './components//Directorio/DirectorioNuevo.vue'


export const routes = [
    {path:'',component: Principal},    
    {path:'/directorio',name:'directorio',component: Directorio, children:
        [
            {path:'nuevo',component:DirectorioNuevo, name: 'userAdd'},            
            {path:':id',component: DirectorioDetalle},
            {path:':id/edit',component:DirectorioEdit}    
        ]
    },
    {path:'/avisos',component: Avisos,children:
        [
            {path:'/nuevo',component:AvisoNuevo},            
            {path:':id',component: AvisoDetalle},
            {path:':id/edit',component:AvisoEdit}    
        ]}
    

];