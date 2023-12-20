import { getModoNoturno, getToken } from '../../core/config/Token';
import Swal, { SweetAlertIcon } from 'sweetalert2'

function AlertaSimples(titulo: string, mensagem: any, icone: any){
        
    const alert = Swal.fire({
        icon: icone,
        title: titulo,
        text: mensagem,
        confirmButtonColor: "#28a745",
        background: getModoNoturno() ? '#101010' : '#fff',
        color: getModoNoturno() ? '#fff' : '#101010'
    });
}

async function AlertaSimplesAsync(titulo: string, mensagem: any, icone: any){
        
    const alert = await Swal.fire({
        icon: icone,
        title: titulo,
        text: mensagem,
        confirmButtonColor: "#28a745",
        background: getModoNoturno() ? '#101010' : '#fff',
        color: getModoNoturno() ? '#fff' : '#101010'
    });
}

function AlertaSimplesResponse(titulo: string, res: any){
    
    const icone = res.status == 201 || res.status == 200 ? "success" : "warning";
    
    const alert = Swal.fire({
        icon: icone,
        confirmButtonColor: "#28a745",
        title: titulo,
        text: res.data,
        background: getModoNoturno() ? '#101010' : '#fff',
        color: getModoNoturno() ? '#fff' : '#101010'
    });

}

function AlertaSimplesErro(titulo: string, err: any){

    if(!err.response){
        const alert = Swal.fire({
            icon: "error",
            title: titulo,
            text: err? err : "Desculpe, um erro desconhecido ocorreu. Por favor, tente novamente! Caso o erro persista entre em contato com nosso suporte para obter ajuda.",
            confirmButtonColor: "#28a745",
            background: getModoNoturno() ? '#101010' : '#fff',
            color: getModoNoturno() ? '#fff' : '#101010'
        });
    }
    else{

        if(err.response.status == 400){    
            const alert = Swal.fire({
                icon: "warning",
                title: titulo,
                text: err.response.data.Mensagem,
                confirmButtonColor: "#28a745",
                background: getModoNoturno() ? '#101010' : '#fff',
                color: getModoNoturno() ? '#fff' : '#101010'
            });
        }
        else if(err.response.status == 403){
            const alert = Swal.fire({
                icon: "warning",
                title: titulo,
                text: err.response.data.Mensagem,
                confirmButtonColor: "#28a745",
                background: getModoNoturno() ? '#101010' : '#fff',
                color: getModoNoturno() ? '#fff' : '#101010'
            });
        }
        else if(err.response.status == 404){
            const alert = Swal.fire({
                icon: "warning",
                title: titulo,
                text: err.response.data.Mensagem,
                confirmButtonColor: "#28a745",
                background: getModoNoturno() ? '#101010' : '#fff',
                color: getModoNoturno() ? '#fff' : '#101010'
            });
        }
        else{
            const alert = Swal.fire({
                icon: "error",
                title: titulo,
                text: err.response.data.Mensagem,
                confirmButtonColor: "#28a745",
                background: getModoNoturno() ? '#101010' : '#fff',
                color: getModoNoturno() ? '#fff' : '#101010'
            });
        }
    }

}

async function AlertaExclusaoQuestao(promise: any){
    const result = await Swal.fire({
        title: 'Atenção!',
        text: 'Tem certeza que deseja excluir o registro atual?',
        icon: 'question',
        showDenyButton: true,
        confirmButtonText: 'Sim',
        denyButtonText: 'Não',
        showCloseButton: true,
        background: getModoNoturno() ? '#101010' : '#fff',
        color: getModoNoturno() ? '#fff' : '#101010',
        preConfirm: () => {
            return promise();
        }   
    });
    if (result.value){
        AlertaSimples("Aviso", "Operação Sucesso", "success");
    }
}

async function AlertExcludeQuestion(promise: any){

    const alert = await Swal.fire({
        title: 'Atenção!',
        text: 'Tem certeza que deseja excluir o registro atual?',
        icon: 'question',
        showDenyButton: true,
        confirmButtonText: 'Sim',
        denyButtonText: 'Não',
        showCloseButton: true,
        preConfirm: () => {
            promise();
        }   
    }).then( (result) => {
        if(result.value){
            AlertaSimples("Aviso", "Operação Sucesso", "success");
        }
    });
}

async function MensagemMixin(tempoMilissegundos: number, icone: SweetAlertIcon, title: string){
    const Toast = Swal.mixin({
        toast: true,
        position: 'top-end',
        showConfirmButton: false,
        timer: tempoMilissegundos,
        timerProgressBar: true,
        didOpen: (toast) => {
          toast.addEventListener('mouseenter', Swal.stopTimer)
          toast.addEventListener('mouseleave', Swal.resumeTimer)
        }
      });
    Toast.fire({
        icon: icone,
        title: title,
        background: getModoNoturno() ? '#101010' : '#fff',
        color: getModoNoturno() ? '#fff' : '#101010'
    });
}

async function AlertaExclusaoQuestaoBooleano(){
    let excluir = false;
    const alert = await Swal.fire({
        title: 'Atenção!',
        text: 'Tem certeza que deseja excluir o registro atual?',
        icon: 'question',
        showDenyButton: true,
        confirmButtonColor : "#28a745",
        confirmButtonText: 'Sim',
        denyButtonText: 'Não',
        focusDeny: true,
        showCloseButton: true,
        background: getModoNoturno() ? '#101010' : '#fff',
        color: getModoNoturno() ? '#fff' : '#101010'
    }).then( (result) => {
        if(result.isConfirmed){
            excluir =  true;
        }
    });
    return excluir;
}

async function AlertaPerguntaSimOuNaoBooleano(pergunta: string, title = ''){
    let excluir = false;
    const alert = await Swal.fire({
        title: title? title : 'Atenção!',
        text: pergunta,
        icon: 'question',
        showDenyButton: true,
        confirmButtonColor : "#28a745",
        confirmButtonText: 'Sim',
        denyButtonText: 'Não',
        focusDeny: true,
        background: getModoNoturno() ? '#101010' : '#fff',
        color: getModoNoturno() ? '#fff' : '#101010'
    }).then( (result) => {
        if(result.isConfirmed){
            excluir =  true;
        }
    });
    return excluir;
}

export{
    AlertaSimples , AlertaSimplesResponse , AlertaSimplesErro , AlertaExclusaoQuestao , AlertaExclusaoQuestaoBooleano, MensagemMixin,
    AlertaPerguntaSimOuNaoBooleano, AlertaSimplesAsync,AlertExcludeQuestion
}