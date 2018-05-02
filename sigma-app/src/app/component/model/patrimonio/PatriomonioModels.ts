import { ModeloModels } from "../modelo/ModeloModels";
import { MarcaModels } from "../marca/MarcaModels";

export class PatrimonioModels {
    public Id: number;
    public Nome: string;
    public Descricao: string;
    public Tombo: string;
    public ModeloId: number;
    public MarcaId: number;
    public Modelo: ModeloModels;
    public Marca: MarcaModels;
}