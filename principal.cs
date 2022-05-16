using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class principal : MonoBehaviour
{
	
	private  AudioSource audio;         //variavel do tipo audiosorce
	public  AudioClip SOM_dinheiro;         //variavel que vai anexar o audio do dinheiro
	public  AudioClip SOM_dinheiro_pouco; 
	public  AudioClip alerta_respeito; 
	public  AudioClip Som_arma; 

	public int dinherio_acumulado;  // vai guaradar o valor do dinheiro tatal
	public int dinhe_parcial;  //vai guardar o dinherio parcial,ou seja oq vc robou na fase
	public int primeira_vez=0;  //variavel que vai guardar a informção da priemira vez que o jogo foi instalado e iniciado

	public int A;  // variavel que vai recber o valor parcial dos caixas explodidos
	public int B;
	public int C;

	public int bala_revolver;
	public int bala_revolver_reserva;
	public int bala_pistola;    //variavel que vai guardar o valor das balas da pistola
	public int sub_bala_pistola;   //variavel que vai guardar o valor das sub_balas da pistola
	public int bala_shootgun;
	public int bala_shootgun_reserva;
	public int bala_ak;
	public int bala_ak_reserva;
	public int bala_m4;
	public int bala_m4_reserva;

	public int respeito ;         //variavel que guarda o valor do respeito
	public int respeito_parcial ;         //variavel que guarda o valor do respeito
	public int controle;            //variavel que vai controlar os avisos de nova arma desbloqueada
	public int adiquiriu_revolver;  //variavel que vai servi pra saber se ja foi comprada a arma ou nao,0 signifca nao e 1,significa sim
	public int adiquiriu_glock;
	public int adiquiriu_shootgun;
	public int adiquiriu_ak;
	public int adiquiriu_m4;

	public int supresa_1; // variavel que vai controlar as supresas de novas armas
	public int supresa_2;
	public int supresa_3;
	public int supresa_4;
	public int nova_arma;

	public int caixas_eletronico;         //vai controlar quantos caixas vc explodiu
	public int kill_pm;       //vai controlar quantos policial vc matou
	public int kill_civil;   //vai controlar quantos civil vc matou

	public GameObject geral_Nova_arma;
	public GameObject geral_butao;
	public GameObject geral_carteira;
	public GameObject panel_preto;
	public GameObject mostra_dinheiro_total;
	public GameObject mostra_din_compra_subtra;
	public GameObject mostra_dinheiro_parcial;
	public GameObject geral_txt_respeito;
	public GameObject geral_txt_respeito_negativo;



	public GameObject ico_feira_revovler;
	public GameObject ico_feira_glock;
	public GameObject ico_feira_ak;
	public GameObject ico_feira_m4;
	public GameObject ico_feira_shootgun;


	public Text infoma_pm;     //aki linka o gui texto que vai mostar o valor de pm mortos
	public Text infoma_civil;
	public Text infoma_caixas;

	public Text mostra_status;
	public Text mostra_bala;           // aki linka o testo que vai mostrar o valor das bala do pente
	public Text mostra_bala_reserva;   //  aki linka o texto que vai mostar o valor das balas reservas
	public Text dinheiro_total;
	public Text dinheiro_parcial;
	public Text dinheiro_total_2;
	public Text txt_respeito;
	public Text txt_respeito_negativo;
	public Text txt_testee;                  //variavel teste
	public Text txt_dinhe_compra;
	public Text txt_dinhe_compra_subtra;

	public bool tuto=false;
    void Start()
    {
		nova_arma=0;
		audio = GetComponent<AudioSource>();   //variavel que vai pegar o componente audio sorce
		primeira_vez=PlayerPrefs.GetInt ("verificação");      //comando que vai pegar o valor salvo,que diz se é a primeria vez do jogo iniciado
		if(primeira_vez==0){
			inicio_padrao(); // carrega os valores padrao de inicio do jogo
		}else{
			StartCoroutine ("load");  //carrega todos os dados setados na coroutine "load"
		}
    }


    
    

	IEnumerator load(){     //coroutine que vai carregar  os dados salvos

		A=PlayerPrefs.GetInt("CIVILP");
		B=PlayerPrefs.GetInt("CAIXASP");
		C=PlayerPrefs.GetInt("PMP");

		controle=PlayerPrefs.GetInt("W");
		respeito=PlayerPrefs.GetInt("YY");
		respeito_parcial=PlayerPrefs.GetInt("YYY");   //pega o valor do playprefs respeito
		dinherio_acumulado=PlayerPrefs.GetInt("ZZ");
		dinhe_parcial=PlayerPrefs.GetInt("XX");

		adiquiriu_revolver=PlayerPrefs.GetInt("K");
		adiquiriu_glock=PlayerPrefs.GetInt("KK");
		adiquiriu_shootgun=PlayerPrefs.GetInt("KKK");
		adiquiriu_ak=PlayerPrefs.GetInt("KKKK");
		adiquiriu_m4=PlayerPrefs.GetInt("KKKKK");

		bala_pistola=PlayerPrefs.GetInt("A");    // "A" referese a variavel global que salva os dados,ou seja esse mesmo "A" vai ta la no script das armas,salvando os valores das balas
		sub_bala_pistola=PlayerPrefs.GetInt("AA");
		bala_revolver=PlayerPrefs.GetInt("B");    //pega o valor salvo da playprefs da bala do revolver
		bala_revolver_reserva=PlayerPrefs.GetInt("BB");
		bala_shootgun=PlayerPrefs.GetInt("C");
		bala_shootgun_reserva=PlayerPrefs.GetInt("CC");
		bala_ak=PlayerPrefs.GetInt("D");
		bala_ak_reserva=PlayerPrefs.GetInt("DD");
		bala_m4=PlayerPrefs.GetInt("E");
		bala_m4_reserva=PlayerPrefs.GetInt("EE");

		supresa_1=PlayerPrefs.GetInt("S");
		supresa_2=PlayerPrefs.GetInt("SS");
		supresa_3=PlayerPrefs.GetInt("SSS");
		supresa_4=PlayerPrefs.GetInt("SSSS");
	
		if(A>0){
			kill_civil=PlayerPrefs.GetInt("CIVILP");
			PlayerPrefs.SetInt ("CIVIL",kill_civil);
			A=0;
			PlayerPrefs.SetInt ("CIVILP",A);
		}else{
		kill_civil=PlayerPrefs.GetInt("CIVIL");
		}
		if(B>0){
		caixas_eletronico=PlayerPrefs.GetInt("CAIXASP");
		PlayerPrefs.SetInt ("CAIXAS",caixas_eletronico);
		B=0;
		PlayerPrefs.SetInt ("CAIXASP",B);
		}else{
				caixas_eletronico=PlayerPrefs.GetInt("CAIXAS");
		}
		if(C>0){
		kill_pm=PlayerPrefs.GetInt("PMP");
		PlayerPrefs.SetInt ("PM",kill_pm);
		C=0;
		PlayerPrefs.SetInt ("PMP",C);
		}else{
				kill_pm=PlayerPrefs.GetInt("PM");
			}
			PlayerPrefs.Save();
		yield return  new WaitForSeconds(0.9f);
	}










	public void excluir_dados (){                  //função que exclui todos os dados salvos

		PlayerPrefs.DeleteAll();   //comando que deleta todos os arquivos salvos
		inicio_padrao(); // carrega os valores padrao de inicio do jogo
		PlayerPrefs.Save(); //salva os valores
	}

	public void inicio_padrao (){
		controle=0;
		respeito=0;
		respeito_parcial=0;
		dinherio_acumulado=2000;  //seta o valor inicial do dinheiro
		dinheiro_total_2.text=(" "+dinherio_acumulado);
		dinhe_parcial=0;

		bala_revolver=5;           //seta o valor inicial da bala do revovler
		bala_revolver_reserva=30;
		bala_pistola=12;     //seta valor inicial da bala da pistola,ou seja o valor padrao do primerio jogo,depois vai ser lido as variaveis playprefs,que guarda os valor das balas salvas                        
		sub_bala_pistola=30;
		bala_shootgun_reserva=16;
		bala_shootgun=8;
		bala_ak=30;
		bala_ak_reserva=30;
		bala_m4=30;
		bala_m4_reserva=30;

		primeira_vez=1;      //seta o valor em 1,ou seja pra avisar que o jogo ja foi jogado mais de 1 vez

		adiquiriu_revolver=0;
		adiquiriu_glock=0;
		adiquiriu_shootgun=0;
		adiquiriu_ak=0;
		adiquiriu_m4=0;

		supresa_1=0; // variavel que vai controlar as supresas de novas armas
	    supresa_2=0;
		supresa_3=0;
		supresa_4=0;
		nova_arma=0;

		kill_pm=0;
		kill_civil=0;
		caixas_eletronico=0;

		PlayerPrefs.SetInt ("PM",kill_pm);
		PlayerPrefs.SetInt ("CIVIL",kill_civil);
		PlayerPrefs.SetInt ("CAIXAS",caixas_eletronico);

		PlayerPrefs.SetInt ("S",supresa_1);  
		PlayerPrefs.SetInt ("SS",supresa_2);
		PlayerPrefs.SetInt ("SSS",supresa_3);
		PlayerPrefs.SetInt ("SSSS",supresa_4);

		PlayerPrefs.SetInt ("K",adiquiriu_revolver);  
		PlayerPrefs.SetInt ("KK",adiquiriu_glock);
		PlayerPrefs.SetInt ("KKK",adiquiriu_shootgun);
		PlayerPrefs.SetInt ("KKKK",adiquiriu_ak);
		PlayerPrefs.SetInt ("KKKKK",adiquiriu_m4);
	
		PlayerPrefs.SetInt ("w",controle);         //aki seta o valor de controle na playprefs
		PlayerPrefs.SetInt ("YYY",respeito_parcial);  //aki seta o valor do respeito na playprefs
		PlayerPrefs.SetInt ("YY",respeito);  //aki seta o valor do respeito na playprefs
		PlayerPrefs.SetInt ("ZZ",dinherio_acumulado); //aki seta o valor do respeito na playprefs
		PlayerPrefs.SetInt ("XX",dinhe_parcial);      //aki seta o valor do respeito na playprefs

		PlayerPrefs.SetInt ("B",bala_revolver);
		PlayerPrefs.SetInt ("BB",bala_revolver_reserva);
		PlayerPrefs.SetInt ("A",bala_pistola); //COMANDO QUE SALVA O VALOR DA MUNIÇÃO RESERVA
		PlayerPrefs.SetInt ("AA",sub_bala_pistola); //COMANDO QUE SALVA O VALOR DA MUNIÇÃO RESERVA
		PlayerPrefs.SetInt ("C",bala_shootgun);
		PlayerPrefs.SetInt ("CC",bala_shootgun_reserva);
		PlayerPrefs.SetInt ("D",bala_ak);
		PlayerPrefs.SetInt ("DD",bala_ak_reserva);
		PlayerPrefs.SetInt ("E",bala_m4);
		PlayerPrefs.SetInt ("EE",bala_m4_reserva);

		PlayerPrefs.SetInt("verificação",primeira_vez);  //salva o valor na playprefs
		PlayerPrefs.Save(); //salva os valores



	}
	IEnumerator  soma_dinheiro(){
		yield return  new WaitForSeconds(0.2f);
		dinherio_acumulado=PlayerPrefs.GetInt("ZZ");
		respeito_parcial=PlayerPrefs.GetInt("YYY");
		dinheiro_total.text=(" "+dinherio_acumulado);
		dinheiro_total_2.text=(" "+dinherio_acumulado);
		dinhe_parcial=PlayerPrefs.GetInt("XX"); 

		dinheiro_parcial.text=(" "+dinhe_parcial);
		if(dinhe_parcial>0){
			yield return  new WaitForSeconds(0.8f);
			geral_butao.SetActive(false);
			geral_carteira.SetActive(false);
			panel_preto.SetActive( true);
			mostra_dinheiro_total.SetActive( true);
			yield return  new WaitForSeconds(2f);
			mostra_dinheiro_parcial.SetActive( false);
			dinherio_acumulado=dinherio_acumulado+dinhe_parcial;
			dinheiro_total.text=(" "+dinherio_acumulado);
			dinheiro_total_2.text=(" "+dinherio_acumulado);
			audio.PlayOneShot (SOM_dinheiro, 1);
			yield return  new WaitForSeconds(2f);
			dinhe_parcial=0;
			mostra_dinheiro_total.SetActive( false);
			//PlayerPrefs.SetInt ("YYY",respeito_parcial);
			//PlayerPrefs.SetInt ("YY",respeito);
			//PlayerPrefs.Save();
			if(respeito_parcial>0){
				txt_respeito.text=("+"+respeito_parcial);
				geral_txt_respeito.SetActive(true);
				audio.PlayOneShot (alerta_respeito, 1);
				yield return  new WaitForSeconds(2f);
				geral_txt_respeito.SetActive(false);
				respeito=respeito+respeito_parcial;
				txt_testee.text=(""+respeito);                    //excluirrr
				respeito_parcial=0;
				PlayerPrefs.SetInt ("YYY",respeito_parcial);
				PlayerPrefs.SetInt ("YY",respeito);
				yield return  new WaitForSeconds(0.5f);
				PlayerPrefs.Save();

				if (nova_arma==1){
					//yield return  new WaitForSeconds(0.5f);
					geral_butao.SetActive(false);
					geral_carteira.SetActive(false);
					panel_preto.SetActive( true);
					geral_Nova_arma.SetActive( true);
					audio.PlayOneShot (Som_arma, 1);
					yield return  new WaitForSeconds(4f);
					panel_preto.SetActive( false);
					geral_butao.SetActive(true);
					geral_carteira.SetActive(true);
					nova_arma=0;
					print("passou na função nova arma 1");
					PlayerPrefs.SetInt ("YYY",respeito_parcial);
					PlayerPrefs.SetInt ("YY",respeito);
					PlayerPrefs.Save();
				}
			
			}

	


			panel_preto.SetActive( false);
			geral_butao.SetActive(true);
			geral_carteira.SetActive(true);

			PlayerPrefs.SetInt ("XX",dinhe_parcial);
			PlayerPrefs.SetInt ("ZZ",dinherio_acumulado);
			PlayerPrefs.Save();
		}
		if(respeito_parcial>0){
			txt_respeito.text=("+"+respeito_parcial);
			yield return  new WaitForSeconds(0.5f);
			geral_butao.SetActive(false);
			panel_preto.SetActive( true);

			geral_txt_respeito.SetActive(true);
			audio.PlayOneShot (alerta_respeito, 1);
			yield return  new WaitForSeconds(1.5f);
			panel_preto.SetActive( false);
			geral_butao.SetActive(true);
			geral_txt_respeito.SetActive(false);
			respeito=respeito+respeito_parcial;
			txt_testee.text=(" "+respeito);                    //excluirrr
			respeito_parcial=0;
			PlayerPrefs.SetInt ("YYY",respeito_parcial);
			PlayerPrefs.SetInt ("YY",respeito);
			PlayerPrefs.Save();
			yield return  new WaitForSeconds(0.5f);           ///////// tempo pra computar o respeito e mostar a nova arma    

		}
		if(respeito_parcial<0){
			txt_respeito_negativo.text=(""+respeito_parcial);
			yield return  new WaitForSeconds(0.5f);
			geral_butao.SetActive(false);
			panel_preto.SetActive( true);

			geral_txt_respeito_negativo.SetActive(true);
			yield return  new WaitForSeconds(1.5f);
			panel_preto.SetActive( false);
			geral_butao.SetActive(true);
			geral_txt_respeito_negativo.SetActive(false);
			respeito=respeito-(-respeito_parcial);
			txt_testee.text=(""+respeito);                    //excluirrr
			respeito_parcial=0;
			PlayerPrefs.SetInt ("YYY",respeito_parcial);
			PlayerPrefs.SetInt ("YY",respeito);
			PlayerPrefs.Save();
		}

		if (nova_arma==1){
		//	yield return  new WaitForSeconds(1f);
			geral_butao.SetActive(false);
			geral_carteira.SetActive(false);
			panel_preto.SetActive( true);
			geral_Nova_arma.SetActive( true);
			audio.PlayOneShot (Som_arma, 1);
			yield return  new WaitForSeconds(4f);
			panel_preto.SetActive( false);
			geral_butao.SetActive(true);
			geral_carteira.SetActive(true);
			nova_arma=0;
			print("passou na função nova arma 2");
			PlayerPrefs.Save();
		}
		PlayerPrefs.Save();

	}

	void Update(){
		txt_testee.text=("SCORE: "+respeito);// EXCLUIR DEPOIS,APENAS TESTE PRA MOSTAR O VALOR DO RESPEITO
		infoma_pm.text=("Policiais Mortos: "+kill_pm);
		infoma_civil.text=("Inocentes Mortos: "+kill_civil);
		infoma_caixas.text=("Caixas Explodidos: "+caixas_eletronico);

		if(adiquiriu_revolver==0 && adiquiriu_glock==0 && adiquiriu_shootgun==0 && adiquiriu_ak==0 && adiquiriu_m4==0){
			tuto=true;
		}else{
			tuto=false;
		}
		txt_dinhe_compra.text=(""+dinherio_acumulado);
		if(respeito<=100){
			ico_feira_glock.SetActive(true);
			mostra_status.color=new Color32 (255, 13, 0, 255);  //vermelho
			mostra_status.text=("Ladrao de Galinha");
		}
		if(respeito>=100){
			ico_feira_glock.SetActive(true);
			mostra_status.color=new Color32 (255, 162, 90, 255); //laranja

			mostra_status.text=("Maconheiro");
		}else{
			ico_feira_glock.SetActive(false);

		}
		if(respeito>=200){
			ico_feira_shootgun.SetActive(true);
			mostra_status.color=new Color32 (255, 255, 255, 255); //branco
			mostra_status.text=("Zé Ruela");
		}else{
			ico_feira_shootgun.SetActive(false);
		}
		if(respeito>=300){
			ico_feira_ak.SetActive(true);
			mostra_status.color=new Color32 (6, 0, 255, 255);  //azul
			mostra_status.text=("Bandido");
		}else{
			ico_feira_ak.SetActive(false);
		}
		if(respeito>=400){
			mostra_status.color=new Color32 (73, 142, 17, 255); //vrede
			ico_feira_m4.SetActive(true);
			mostra_status.text=("Ladrao De Banco");
		}else{
			ico_feira_m4.SetActive(false);
		}

		if(supresa_1==0 && respeito>=100){
			nova_arma=1;
			supresa_1=1;
			PlayerPrefs.SetInt ("S",supresa_1); //salva o valor na playprefs
			PlayerPrefs.Save();
			print(" supresa 1");
		}
		if(supresa_2==0 && respeito>=200){
			nova_arma=1;
			supresa_2=1;
			PlayerPrefs.SetInt ("SS",supresa_2); //salva o valor na playprefs
			PlayerPrefs.Save();
			print(" supresa 2");
		}
		if(supresa_3==0 && respeito>=300){
			nova_arma=1;
			supresa_3=1;
			PlayerPrefs.SetInt ("SSS",supresa_3); //salva o valor na playprefs
			PlayerPrefs.Save();
			print(" supresa 3");
		}
		if(supresa_4==0 && respeito>=400){
			nova_arma=1;
			supresa_4=1;
			PlayerPrefs.SetInt ("SSSS",supresa_4); //salva o valor na playprefs
			PlayerPrefs.Save();
			print(" supresa 4");
		}
	}

	void bala_revolver_valor (){
		mostra_bala_reserva.text=("/  "+bala_revolver_reserva);
		mostra_bala.text=(" "+bala_revolver);

	}

	void bala_pistola_valor (){
		mostra_bala_reserva.text=("/  "+sub_bala_pistola);
		mostra_bala.text=(" "+bala_pistola);

	}

	void bala_shootgun_valor (){
		mostra_bala_reserva.text=("/  "+bala_shootgun_reserva);
		mostra_bala.text=(" "+bala_shootgun);

	}
	void bala_ak_valor (){
		mostra_bala_reserva.text=("/  "+bala_ak_reserva);
		mostra_bala.text=(" "+bala_ak);

	}
	void bala_m4_valor (){
		mostra_bala_reserva.text=("/  "+bala_m4_reserva);
		mostra_bala.text=(" "+bala_m4);

	}

	//-------------------------- loja revolver

	IEnumerator  compra_revolver(){
		if (dinherio_acumulado>=1500){
			txt_dinhe_compra_subtra.text=(""+-1500);  // aki mostra no texto subtração o valor a ser abatido
			mostra_din_compra_subtra.SetActive(true); //aki ativa o texto que tem o valor da arma
			audio.PlayOneShot (SOM_dinheiro, 1);        //comando que toca o audio
			yield return  new WaitForSeconds(0.5f);     // aki espera 1 segundo
			mostra_din_compra_subtra.SetActive(false);  //aki desativa o texto
			dinherio_acumulado=dinherio_acumulado-1500; //  aki faz o calculo 
			adiquiriu_revolver=1;                       //aki seta a variavel dizendo que vc comprou
			PlayerPrefs.SetInt ("ZZ",dinherio_acumulado); //aki seta o valor na playprefs
			PlayerPrefs.SetInt ("K",adiquiriu_revolver);  //aki seta o valor ,avisando que a arma foi comprada
			PlayerPrefs.Save();                           //comando que salva os valores setados nas suas playprefs
		}else{
			audio.PlayOneShot (SOM_dinheiro_pouco, 1);    //comando que toca o audio
		}
	
	
	}
	IEnumerator  compra_revolver_bala(){
		if (dinherio_acumulado>=40 && bala_revolver_reserva<120 ){   //aki faz a comparação 
			txt_dinhe_compra_subtra.text=(""+-40);               //comando que mostra o valor da variavel no texto      
			audio.PlayOneShot (SOM_dinheiro, 1);                //comando que toca o audio
			mostra_din_compra_subtra.SetActive(true);           //aki ativa o texto que tem o valor da arma
			dinherio_acumulado=dinherio_acumulado-40;            //aki faz o calculo de subtrair o dinheiro
			yield return  new WaitForSeconds(0.5f);             // comando que espera 0.5 segundo
			mostra_din_compra_subtra.SetActive(false);         //comnado que desativa o gameobject
			bala_revolver_reserva=bala_revolver_reserva+10;    //aki faz o calculo de somar as balas
			if(bala_revolver_reserva>120){
				bala_revolver_reserva=120;
				bala_revolver=5;
			}
			PlayerPrefs.SetInt ("B",bala_revolver);                    //aki seta o valor na playprefs
			PlayerPrefs.SetInt ("BB",bala_revolver_reserva);          //aki seta o valor na playprefs
			mostra_bala.text=(""+bala_revolver);                      //comando que mostra o valor da variavel no texto
			mostra_bala_reserva.text=("/"+bala_revolver_reserva);    //comando que mostra o valor da variavel no texto
			PlayerPrefs.SetInt ("ZZ",dinherio_acumulado);           //aki seta o valor na playprefs
			yield return  new WaitForSeconds(0.9f);                  //comando que espera 0.9 segundos
			PlayerPrefs.Save();                                       //comando que salva os valores na playprefs
		}else{
			audio.PlayOneShot (SOM_dinheiro_pouco, 1);                //comando que toca o audio
		}


	}

	//-------------------------- loja glock

	IEnumerator  compra_pistola (){
		if (dinherio_acumulado>=3000){
			txt_dinhe_compra_subtra.text=(""+-3000);  // aki mostra no texto subtração o valor a ser abatido
			mostra_din_compra_subtra.SetActive(true); //aki ativa o texto que tem o valor da arma
			audio.PlayOneShot (SOM_dinheiro, 1);        //comando que toca o audio
			yield return  new WaitForSeconds(0.5f);     // aki espera 1 segundo
			mostra_din_compra_subtra.SetActive(false);  //aki desativa o texto
			dinherio_acumulado=dinherio_acumulado-3000; //  aki faz o calculo 
			adiquiriu_glock=1;                       //aki seta a variavel dizendo que vc comprou
			PlayerPrefs.SetInt ("ZZ",dinherio_acumulado); //aki seta o valor na playprefs
			PlayerPrefs.SetInt ("KK",adiquiriu_glock);  //aki seta o valor ,avisando que a arma foi comprada
			PlayerPrefs.Save();                           //comando que salva os valores setados nas suas playprefs
		}else{
			audio.PlayOneShot (SOM_dinheiro_pouco, 1);     //comando que toca o audio
		}


	}
	IEnumerator  compra_pistola_bala(){
		if (dinherio_acumulado>=80 && sub_bala_pistola<200 ){   //aki faz a comparação 
			txt_dinhe_compra_subtra.text=(""+-80);              //comando que mostra o valor da variavel no texto
			audio.PlayOneShot (SOM_dinheiro, 1);              //comando que toca o audio
			mostra_din_compra_subtra.SetActive(true);         //aki ativa o texto que tem o valor da arma
			dinherio_acumulado=dinherio_acumulado-80;        //aki faz o calculo de subtrair o dinheiro
			yield return  new WaitForSeconds(0.5f);     // aki espera 1 segundo
			mostra_din_compra_subtra.SetActive(false);   //comando que desativa o gameobject
			sub_bala_pistola=sub_bala_pistola+12;    //aki faz o calculo de somar as balas
			if(sub_bala_pistola>200){               
				sub_bala_pistola=200;
				bala_pistola=12;
			}
			PlayerPrefs.SetInt ("A",bala_pistola);               //aki seta o valor na playprefs
			PlayerPrefs.SetInt ("AA",sub_bala_pistola);         //aki seta o valor na playprefs
			PlayerPrefs.SetInt ("ZZ",dinherio_acumulado);           //aki seta o valor na playprefs
			mostra_bala.text=(""+bala_pistola);                  //comando que mostra o valor da variavel no texto
			mostra_bala_reserva.text=("/"+sub_bala_pistola);      //comando que mostra o valor da variavel no texto
			yield return  new WaitForSeconds(0.9f);            //comando que espera 0.9 segundos
			PlayerPrefs.Save();                               //comando que salva os valores na playprefs
		}else{
			audio.PlayOneShot (SOM_dinheiro_pouco, 1);  //comando que toca o audio
		}


	}


	//-------------------------- loja shootgun

	IEnumerator  compra_shootgun (){
		if (dinherio_acumulado>=5000){
			txt_dinhe_compra_subtra.text=(""+-5000);  // aki mostra no texto subtração o valor a ser abatido
			mostra_din_compra_subtra.SetActive(true); //aki ativa o texto que tem o valor da arma
			audio.PlayOneShot (SOM_dinheiro, 1);        //comando que toca o audio
			yield return  new WaitForSeconds(0.5f);     // aki espera 1 segundo
			mostra_din_compra_subtra.SetActive(false);  //aki desativa o texto
			dinherio_acumulado=dinherio_acumulado-5000; //  aki faz o calculo 
			adiquiriu_shootgun=1;                       //aki seta a variavel dizendo que vc comprou
			PlayerPrefs.SetInt ("ZZ",dinherio_acumulado); //aki seta o valor na playprefs
			PlayerPrefs.SetInt ("KKK",adiquiriu_shootgun);  //aki seta o valor ,avisando que a arma foi comprada
			PlayerPrefs.Save();                           //comando que salva os valores setados nas suas playprefs
		}else{
			audio.PlayOneShot (SOM_dinheiro_pouco, 1);     //comando que toca o audio
		}


	}
	IEnumerator  compra_shootgun_bala(){
		if (dinherio_acumulado>=80 && bala_shootgun_reserva<200 ){   //aki faz a comparação 
			txt_dinhe_compra_subtra.text=(""+-80);              //comando que mostra o valor da variavel no texto
			audio.PlayOneShot (SOM_dinheiro, 1);              //comando que toca o audio
			mostra_din_compra_subtra.SetActive(true);         //aki ativa o texto que tem o valor da arma
			dinherio_acumulado=dinherio_acumulado-80;        //aki faz o calculo de subtrair o dinheiro
			yield return  new WaitForSeconds(0.5f);     // aki espera 1 segundo
			mostra_din_compra_subtra.SetActive(false);   //comando que desativa o gameobject
			bala_shootgun_reserva=bala_shootgun_reserva+16;    //aki faz o calculo de somar as balas
			if(bala_shootgun_reserva>200){               
				bala_shootgun_reserva=200;
				bala_shootgun=8;
			}
			PlayerPrefs.SetInt ("C",bala_shootgun);               //aki seta o valor na playprefs
			PlayerPrefs.SetInt ("CC",bala_shootgun_reserva);         //aki seta o valor na playprefs
			PlayerPrefs.SetInt ("ZZ",dinherio_acumulado);           //aki seta o valor na playprefs
			mostra_bala.text=(""+bala_shootgun);                  //comando que mostra o valor da variavel no texto
			mostra_bala_reserva.text=("/"+bala_shootgun_reserva);      //comando que mostra o valor da variavel no texto
			yield return  new WaitForSeconds(0.9f);            //comando que espera 0.9 segundos
			PlayerPrefs.Save();                               //comando que salva os valores na playprefs
		}else{
			audio.PlayOneShot (SOM_dinheiro_pouco, 1);  //comando que toca o audio
		}


	}

	//-------------------------- loja AK

	IEnumerator  compra_ak (){
		if (dinherio_acumulado>=8000){
			txt_dinhe_compra_subtra.text=(""+-8000);  // aki mostra no texto subtração o valor a ser abatido
			mostra_din_compra_subtra.SetActive(true); //aki ativa o texto que tem o valor da arma
			audio.PlayOneShot (SOM_dinheiro, 1);        //comando que toca o audio
			yield return  new WaitForSeconds(0.5f);     // aki espera 1 segundo
			mostra_din_compra_subtra.SetActive(false);  //aki desativa o texto
			dinherio_acumulado=dinherio_acumulado-8000; //  aki faz o calculo 
			adiquiriu_ak=1;                       //aki seta a variavel dizendo que vc comprou
			PlayerPrefs.SetInt ("ZZ",dinherio_acumulado); //aki seta o valor na playprefs
			PlayerPrefs.SetInt ("KKKK",adiquiriu_ak);  //aki seta o valor ,avisando que a arma foi comprada
			PlayerPrefs.Save();                           //comando que salva os valores setados nas suas playprefs
		}else{
			audio.PlayOneShot (SOM_dinheiro_pouco, 1);     //comando que toca o audio
		}


	}
	IEnumerator  compra_ak_bala(){
		if (dinherio_acumulado>=120 && bala_ak_reserva<300 ){   //aki faz a comparação 
			txt_dinhe_compra_subtra.text=(""+-120);              //comando que mostra o valor da variavel no texto
			audio.PlayOneShot (SOM_dinheiro, 1);              //comando que toca o audio
			mostra_din_compra_subtra.SetActive(true);         //aki ativa o texto que tem o valor da arma
			dinherio_acumulado=dinherio_acumulado-120;        //aki faz o calculo de subtrair o dinheiro
			yield return  new WaitForSeconds(0.5f);     // aki espera 1 segundo
			mostra_din_compra_subtra.SetActive(false);   //comando que desativa o gameobject
			bala_ak_reserva=bala_ak_reserva+30;    //aki faz o calculo de somar as balas
			if(bala_ak_reserva>300){               
				bala_ak_reserva=300;
				bala_ak=30;
			}
			PlayerPrefs.SetInt ("D",bala_ak);               //aki seta o valor na playprefs
			PlayerPrefs.SetInt ("DD",bala_ak_reserva);         //aki seta o valor na playprefs
			PlayerPrefs.SetInt ("ZZ",dinherio_acumulado);           //aki seta o valor na playprefs
			mostra_bala.text=(""+bala_ak);                  //comando que mostra o valor da variavel no texto
			mostra_bala_reserva.text=("/"+bala_ak_reserva);      //comando que mostra o valor da variavel no texto
			yield return  new WaitForSeconds(0.9f);            //comando que espera 0.9 segundos
			PlayerPrefs.Save();                               //comando que salva os valores na playprefs
		}else{
			audio.PlayOneShot (SOM_dinheiro_pouco, 1);  //comando que toca o audio
		}


	}

	//-------------------------- loja m4

	IEnumerator  compra_m4 (){
		if (dinherio_acumulado>=8000){
			txt_dinhe_compra_subtra.text=(""+-8000);  // aki mostra no texto subtração o valor a ser abatido
			mostra_din_compra_subtra.SetActive(true); //aki ativa o texto que tem o valor da arma
			audio.PlayOneShot (SOM_dinheiro, 1);        //comando que toca o audio
			yield return  new WaitForSeconds(0.5f);     // aki espera 1 segundo
			mostra_din_compra_subtra.SetActive(false);  //aki desativa o texto
			dinherio_acumulado=dinherio_acumulado-8000; //  aki faz o calculo 
			adiquiriu_m4=1;                       //aki seta a variavel dizendo que vc comprou
			PlayerPrefs.SetInt ("ZZ",dinherio_acumulado); //aki seta o valor na playprefs
			PlayerPrefs.SetInt ("KKKKK",adiquiriu_m4);  //aki seta o valor ,avisando que a arma foi comprada
			PlayerPrefs.Save();                           //comando que salva os valores setados nas suas playprefs
		}else{
			audio.PlayOneShot (SOM_dinheiro_pouco, 1);     //comando que toca o audio
		}


	}
	IEnumerator  compra_m4_bala(){
		if (dinherio_acumulado>=120 && bala_m4_reserva<300 ){   //aki faz a comparação 
			txt_dinhe_compra_subtra.text=(""+-120);              //comando que mostra o valor da variavel no texto
			audio.PlayOneShot (SOM_dinheiro, 1);              //comando que toca o audio
			mostra_din_compra_subtra.SetActive(true);         //aki ativa o texto que tem o valor da arma
			dinherio_acumulado=dinherio_acumulado-120;        //aki faz o calculo de subtrair o dinheiro
			yield return  new WaitForSeconds(0.5f);     // aki espera 1 segundo
			mostra_din_compra_subtra.SetActive(false);   //comando que desativa o gameobject
			bala_m4_reserva=bala_m4_reserva+30;    //aki faz o calculo de somar as balas
			if(bala_m4_reserva>300){               
				bala_m4_reserva=300;
				bala_m4=30;
			}
			PlayerPrefs.SetInt ("E",bala_m4);               //aki seta o valor na playprefs
			PlayerPrefs.SetInt ("EE",bala_m4_reserva);         //aki seta o valor na playprefs
			PlayerPrefs.SetInt ("ZZ",dinherio_acumulado);           //aki seta o valor na playprefs
			mostra_bala.text=(""+bala_m4);                  //comando que mostra o valor da variavel no texto
			mostra_bala_reserva.text=("/"+bala_m4_reserva);      //comando que mostra o valor da variavel no texto
			yield return  new WaitForSeconds(0.9f);            //comando que espera 0.9 segundos
			PlayerPrefs.Save();                               //comando que salva os valores na playprefs
		}else{
			audio.PlayOneShot (SOM_dinheiro_pouco, 1);  //comando que toca o audio
		}


	}

	public void abreSite2 ()
	{
		Application.OpenURL("http://vaka.me/1049449");
	}




}
