import { Vue } from "vue-property-decorator";
import { JSONToCSVConvertor, TableToExcel } from '@/assets/scripts/helper';

export class PageBase extends Vue {

    public sessionApp: any;
    public app: { usuarioId: number, usuarioNome: string, usuarioFoto: string, usuarioEmail: string } = {
        usuarioId: 0,
        usuarioNome: '',
        usuarioFoto: '',
        usuarioEmail: ''
    };

    constructor() {
        super();

        // if (!localStorage.sessionApp) {
        //     this.$router.push({ name: 'Login' });
        //     return;
        // }

        // this.sessionApp = JSON.parse(localStorage.sessionApp);

        // this.app.usuarioId = this.sessionApp.dados.usuarioId;
        // this.app.usuarioNome = this.sessionApp.dados.usuarioNome;
        // this.app.usuarioFoto = this.sessionApp.dados.usuarioFoto;
        // this.app.usuarioEmail = this.sessionApp.dados.usuarioEmail;

    }

    ExportarExcel(tabela: string, worksheet?: string) {
        TableToExcel(tabela, worksheet);
    }

    JsonToCSV(JSONData: JSON, ReportTitle: string, ShowLabel: boolean) {
        JSONToCSVConvertor(JSONData, ReportTitle, ShowLabel);
    }
}