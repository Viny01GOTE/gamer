using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class dinheiro : MonoBehaviour
{
	private  AudioSource audio;         //variavel do tipo audiosorce
	public  AudioClip alerta_respeito;         //variavel que vai anexar o audio do alerta quando ganhar respeito


	public int info_caixas;
	public int info_pm;
	public int info_civil;

	public int respeito_parcial=0; //variavel que vai guardar o valor do respeito parcial
	private int sorteio_respeito;    //variavel que vai receber o valor sorteado
	private int sorteio;                    //variavel que vai receber o valor sorteado
	public int dinh_parcial;              //  variavel que vai receber o valor dos dinheiros roubados
	public Text mostra_dinheiro_parcial;   //  vairavel que anexa o text da tela,pra mostrar o valor do dinheiro
	public Text mostra_dinheiro_sorteado;  //  vairavel que anexa o text da tela,pra mostrar o valor do dinheiro sorteado
	public Text texto_respeito;            // aki seta o texto que ai mostrar o respeito
	public Text texto_respeito_negativo;            // aki seta o texto que ai mostrar o respeito

	public Text texto_caixas;   // aki linca o txt que vai mostrar o valor de caixas estourados
	public Text texto_civil;
	public Text texto_pm;

	//public Color cor_negativo;
	public  GameObject mostra_respeito ;  //aki linka o geral que tem os textos referente ao respeito
	public  GameObject mostra_respeito_negativo ;  //aki linka o geral que tem os textos referente ao respeito
	public  GameObject dinhe_sorteado ;    //aki linka o geral que tem os textos referente ao dinheiro

    void Start()
    {
		audio = GetComponent<AudioSource>();   //variavel que vai pegar o componente audio sorce
		load_info();
    }


   

	IEnumerator sorteio_dinheiro (){ 
		sorteio=Random.Range(500,1500);
		dinhe_sorteado.SetActive( true);
		mostra_dinheiro_sorteado.text=("+"+sorteio); 
		yield return  new WaitForSeconds (1f);
		dinhe_sorteado.SetActive( false);
		dinh_parcial=dinh_parcial+sorteio;
		mostra_dinheiro_parcial.text=(" "+dinh_parcial);
		sorteio=0;
	}
	IEnumerator sorteio_dinheiro2 (){ 
		sorteio=Random.Range(6000,15000);
		dinhe_sorteado.SetActive( true);
		mostra_dinheiro_sorteado.text=("+"+sorteio); 
		yield return  new WaitForSeconds (1f);
		dinhe_sorteado.SetActive( false);
		dinh_parcial=dinh_parcial+sorteio;
		mostra_dinheiro_parcial.text=(" "+dinh_parcial);
		sorteio=0;
	}

	IEnumerator sorteio_real (){ 
		sorteio=Random.Range(50,250);
		dinhe_sorteado.SetActive( true);
		mostra_dinheiro_sorteado.text=("+"+sorteio); 
		yield return  new WaitForSeconds (1f);
		dinhe_sorteado.SetActive( false);
		dinh_parcial=dinh_parcial+sorteio;
		mostra_dinheiro_parcial.text=(" "+dinh_parcial);
		sorteio=0;
	}

	IEnumerator sorteio_real2 (){ 
		sorteio=Random.Range(200,450);
		dinhe_sorteado.SetActive( true);
		mostra_dinheiro_sorteado.text=("+"+sorteio); 
		yield return  new WaitForSeconds (1f);
		dinhe_sorteado.SetActive( false);
		dinh_parcial=dinh_parcial+sorteio;
		mostra_dinheiro_parcial.text=(" "+dinh_parcial);
		sorteio=0;
	}

	public void  salva_progresso(){
		PlayerPrefs.SetInt ("YYY",respeito_parcial);
		PlayerPrefs.SetInt ("XX",dinh_parcial);
		PlayerPrefs.Save();


	}

	IEnumerator sortea_respeito (){
		sorteio_respeito=Random.Range(5,20);
		respeito_parcial=respeito_parcial+sorteio_respeito;
		texto_respeito.text=("+"+sorteio_respeito);
		if(mostra_respeito_negativo==true){
			mostra_respeito_negativo.SetActive( false);
		}
		mostra_respeito.SetActive( true);
		audio.PlayOneShot (alerta_respeito, 1);
		yield return  new WaitForSeconds (2f);
		mostra_respeito.SetActive( false);
		sorteio_respeito=0;
		PlayerPrefs.SetInt ("YYY",respeito_parcial);
	}

	IEnumerator sortea_respeito_Unico (){    //sortei usado para quando matar um npc da força nacional
		sorteio_respeito=5;
		respeito_parcial=respeito_parcial+sorteio_respeito;
		texto_respeito.text=("+"+sorteio_respeito);
		if(mostra_respeito_negativo==true){
			mostra_respeito_negativo.SetActive( false);
		}
		mostra_respeito.SetActive( true);
		audio.PlayOneShot (alerta_respeito, 1);
		yield return  new WaitForSeconds (2f);
		mostra_respeito.SetActive( false);
		sorteio_respeito=0;
		PlayerPrefs.SetInt ("YYY",respeito_parcial);
	}

	IEnumerator sortea_respeito_negativo (){
		sorteio_respeito=Random.Range(100,400);
		respeito_parcial=respeito_parcial-sorteio_respeito;
		//texto_respeito.color = cor_negativo;
		texto_respeito_negativo.text=("-"+sorteio_respeito);
		if(mostra_respeito==true){
			mostra_respeito.SetActive( false);
		}
		mostra_respeito_negativo.SetActive( true);
		yield return  new WaitForSeconds (2f);
		mostra_respeito_negativo.SetActive( false);
		sorteio_respeito=0;
		PlayerPrefs.SetInt ("YYY",respeito_parcial);
	}

	public void zeraRespeito (){
		
		if(respeito_parcial>=0){
			respeito_parcial=0;
		}
		PlayerPrefs.SetInt ("YYY",respeito_parcial);  //seta o valor na playprefs	
		PlayerPrefs.SetInt ("XX",dinh_parcial);
		PlayerPrefs.Save();  
	}
	public void zeraRespeitoDinheiro (){

		respeito_parcial=0;
		dinh_parcial=0;
		PlayerPrefs.SetInt ("YYY",respeito_parcial);  //seta o valor na playprefs	
		PlayerPrefs.SetInt ("XX",dinh_parcial);
		PlayerPrefs.Save();  
	}


	public void Morreu(){       //  void que vai zerar o respeito eo dinheiro caso vc morra
		respeito_parcial=0;
		dinh_parcial=0;
		PlayerPrefs.SetInt ("YYY",respeito_parcial);  //seta o valor na playprefs
		PlayerPrefs.SetInt ("XX",dinh_parcial);      //seta o valor na playprefs
		info_pm=0;
		info_civil=0;
		info_caixas=0;
		PlayerPrefs.SetInt ("CIVILP",info_civil);
		PlayerPrefs.SetInt ("PMP",info_pm);
		PlayerPrefs.SetInt ("CAIXASP",info_caixas);

		PlayerPrefs.Save();                          //salva o playprefs
	}


	public void ADD_PM(){ 
		info_pm=info_pm+1;
		PlayerPrefs.SetInt ("PMP",info_pm);
		texto_pm.text=(" "+info_pm);
	}
	public void ADD_CIVIL(){ 
		info_civil=info_civil+1;
		PlayerPrefs.SetInt ("CIVILP",info_civil);
		texto_civil.text=(" "+info_civil);
	}
	public void ADD_CAIXAS(){ 
		info_caixas=info_caixas+1;
		PlayerPrefs.SetInt ("CAIXASP",info_caixas);
		texto_caixas.text=(" "+info_caixas);
	}

	public void load_info(){
		info_pm=PlayerPrefs.GetInt("PM");
		info_civil=PlayerPrefs.GetInt("CIVIL");
		info_caixas=PlayerPrefs.GetInt("CAIXAS");

		texto_caixas.text=(" "+info_caixas);
		texto_civil.text=(" "+info_civil);
		texto_pm.text=(" "+info_pm);
	}

	public void abreSite ()
	{
		Application.OpenURL("http://vaka.me/1049449");
	}

}
