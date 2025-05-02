#pragma once

#include <mysql_driver.h>        // Driver de MySQL
#include <mysql_connection.h>    // Connexió a MySQL
#include <cppconn/statement.h>   // Per executar consultes SQL
#include <cppconn/resultset.h>   // Per gestionar resultats de consultes
#include <cppconn/prepared_statement.h>  // Per consultes preparades

#include "Connexio.h"


namespace CppCLRWinFormsProject {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

	/// <summary>
	/// Summary for Form1
	/// </summary>
	public ref class Form1 : public System::Windows::Forms::Form
	{
	public:
		Form1(void)
		{
			InitializeComponent();
			//
			//TODO: Add the constructor code here
			//
		}

	protected:
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		~Form1()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Windows::Forms::GroupBox^ groupBox1;
	private: System::Windows::Forms::Label^ label5;
	private: System::Windows::Forms::Label^ label4;
	private: System::Windows::Forms::Label^ label3;
	private: System::Windows::Forms::Label^ label2;
	private: System::Windows::Forms::Label^ label1;

	private: System::Windows::Forms::TextBox^ txtExistencies;


	private: System::Windows::Forms::TextBox^ txtPreu;

	private: System::Windows::Forms::TextBox^ txtDescripcio;

	private: System::Windows::Forms::TextBox^ txtNom;

	private: System::Windows::Forms::TextBox^ txtCodi;
	private: System::Windows::Forms::Button^ btnBuscar;
	private: System::Windows::Forms::Button^ btnGuardar;
	private: System::Windows::Forms::Button^ btnActualitzar;
	private: System::Windows::Forms::Button^ btnEliminar;
	private: System::Windows::Forms::Button^ BtnNetejar;

	protected:

	private:
		/// <summary>
		/// Required designer variable.
		/// </summary>
		System::ComponentModel::Container ^components;

#pragma region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		void InitializeComponent(void)
		{
			this->groupBox1 = (gcnew System::Windows::Forms::GroupBox());
			this->btnBuscar = (gcnew System::Windows::Forms::Button());
			this->txtExistencies = (gcnew System::Windows::Forms::TextBox());
			this->txtPreu = (gcnew System::Windows::Forms::TextBox());
			this->txtDescripcio = (gcnew System::Windows::Forms::TextBox());
			this->txtNom = (gcnew System::Windows::Forms::TextBox());
			this->txtCodi = (gcnew System::Windows::Forms::TextBox());
			this->label5 = (gcnew System::Windows::Forms::Label());
			this->label4 = (gcnew System::Windows::Forms::Label());
			this->label3 = (gcnew System::Windows::Forms::Label());
			this->label2 = (gcnew System::Windows::Forms::Label());
			this->label1 = (gcnew System::Windows::Forms::Label());
			this->btnGuardar = (gcnew System::Windows::Forms::Button());
			this->btnActualitzar = (gcnew System::Windows::Forms::Button());
			this->btnEliminar = (gcnew System::Windows::Forms::Button());
			this->BtnNetejar = (gcnew System::Windows::Forms::Button());
			this->groupBox1->SuspendLayout();
			this->SuspendLayout();
			// 
			// groupBox1
			// 
			this->groupBox1->Controls->Add(this->btnBuscar);
			this->groupBox1->Controls->Add(this->txtExistencies);
			this->groupBox1->Controls->Add(this->txtPreu);
			this->groupBox1->Controls->Add(this->txtDescripcio);
			this->groupBox1->Controls->Add(this->txtNom);
			this->groupBox1->Controls->Add(this->txtCodi);
			this->groupBox1->Controls->Add(this->label5);
			this->groupBox1->Controls->Add(this->label4);
			this->groupBox1->Controls->Add(this->label3);
			this->groupBox1->Controls->Add(this->label2);
			this->groupBox1->Controls->Add(this->label1);
			this->groupBox1->Location = System::Drawing::Point(45, 30);
			this->groupBox1->Name = L"groupBox1";
			this->groupBox1->Size = System::Drawing::Size(417, 330);
			this->groupBox1->TabIndex = 0;
			this->groupBox1->TabStop = false;
			this->groupBox1->Text = L"Dades del producte";
			this->groupBox1->Enter += gcnew System::EventHandler(this, &Form1::groupBox1_Enter);
			// 
			// btnBuscar
			// 
			this->btnBuscar->Location = System::Drawing::Point(305, 35);
			this->btnBuscar->Name = L"btnBuscar";
			this->btnBuscar->Size = System::Drawing::Size(80, 23);
			this->btnBuscar->TabIndex = 11;
			this->btnBuscar->Text = L"Buscar";
			this->btnBuscar->UseVisualStyleBackColor = true;
			this->btnBuscar->Click += gcnew System::EventHandler(this, &Form1::btnBuscar_Click);
			// 
			// txtExistencies
			// 
			this->txtExistencies->Location = System::Drawing::Point(171, 253);
			this->txtExistencies->Name = L"txtExistencies";
			this->txtExistencies->Size = System::Drawing::Size(110, 22);
			this->txtExistencies->TabIndex = 9;
			// 
			// txtPreu
			// 
			this->txtPreu->Location = System::Drawing::Point(171, 210);
			this->txtPreu->Name = L"txtPreu";
			this->txtPreu->Size = System::Drawing::Size(110, 22);
			this->txtPreu->TabIndex = 8;
			// 
			// txtDescripcio
			// 
			this->txtDescripcio->Location = System::Drawing::Point(171, 133);
			this->txtDescripcio->Multiline = true;
			this->txtDescripcio->Name = L"txtDescripcio";
			this->txtDescripcio->Size = System::Drawing::Size(214, 55);
			this->txtDescripcio->TabIndex = 7;
			// 
			// txtNom
			// 
			this->txtNom->Location = System::Drawing::Point(171, 84);
			this->txtNom->Name = L"txtNom";
			this->txtNom->Size = System::Drawing::Size(214, 22);
			this->txtNom->TabIndex = 6;
			// 
			// txtCodi
			// 
			this->txtCodi->Location = System::Drawing::Point(171, 35);
			this->txtCodi->Name = L"txtCodi";
			this->txtCodi->Size = System::Drawing::Size(110, 22);
			this->txtCodi->TabIndex = 5;
			// 
			// label5
			// 
			this->label5->AutoSize = true;
			this->label5->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 10.2F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->label5->Location = System::Drawing::Point(21, 253);
			this->label5->Name = L"label5";
			this->label5->Size = System::Drawing::Size(100, 20);
			this->label5->TabIndex = 4;
			this->label5->Text = L"Existencies:";
			// 
			// label4
			// 
			this->label4->AutoSize = true;
			this->label4->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 10.2F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->label4->Location = System::Drawing::Point(23, 210);
			this->label4->Name = L"label4";
			this->label4->Size = System::Drawing::Size(98, 20);
			this->label4->TabIndex = 3;
			this->label4->Text = L"Preu públic:";
			// 
			// label3
			// 
			this->label3->AutoSize = true;
			this->label3->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 10.2F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->label3->Location = System::Drawing::Point(26, 133);
			this->label3->Name = L"label3";
			this->label3->Size = System::Drawing::Size(95, 20);
			this->label3->TabIndex = 2;
			this->label3->Text = L"Descripció:";
			// 
			// label2
			// 
			this->label2->AutoSize = true;
			this->label2->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 10.2F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->label2->Location = System::Drawing::Point(26, 84);
			this->label2->Name = L"label2";
			this->label2->Size = System::Drawing::Size(49, 20);
			this->label2->TabIndex = 1;
			this->label2->Text = L"Nom:";
			// 
			// label1
			// 
			this->label1->AutoSize = true;
			this->label1->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 10.2F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->label1->Location = System::Drawing::Point(26, 35);
			this->label1->Name = L"label1";
			this->label1->Size = System::Drawing::Size(48, 20);
			this->label1->TabIndex = 0;
			this->label1->Text = L"Codi:";
			// 
			// btnGuardar
			// 
			this->btnGuardar->Location = System::Drawing::Point(44, 373);
			this->btnGuardar->Name = L"btnGuardar";
			this->btnGuardar->Size = System::Drawing::Size(75, 34);
			this->btnGuardar->TabIndex = 12;
			this->btnGuardar->Text = L"Guardar";
			this->btnGuardar->UseVisualStyleBackColor = true;
			this->btnGuardar->Click += gcnew System::EventHandler(this, &Form1::btnGuardar_Click);
			// 
			// btnActualitzar
			// 
			this->btnActualitzar->Location = System::Drawing::Point(155, 373);
			this->btnActualitzar->Name = L"btnActualitzar";
			this->btnActualitzar->Size = System::Drawing::Size(89, 34);
			this->btnActualitzar->TabIndex = 13;
			this->btnActualitzar->Text = L"Actualitzar";
			this->btnActualitzar->UseVisualStyleBackColor = true;
			this->btnActualitzar->Click += gcnew System::EventHandler(this, &Form1::btnActualitzar_Click);
			// 
			// btnEliminar
			// 
			this->btnEliminar->Location = System::Drawing::Point(273, 373);
			this->btnEliminar->Name = L"btnEliminar";
			this->btnEliminar->Size = System::Drawing::Size(81, 34);
			this->btnEliminar->TabIndex = 14;
			this->btnEliminar->Text = L"Eliminar";
			this->btnEliminar->UseVisualStyleBackColor = true;
			this->btnEliminar->Click += gcnew System::EventHandler(this, &Form1::btnEliminar_Click);
			// 
			// BtnNetejar
			// 
			this->BtnNetejar->Location = System::Drawing::Point(381, 373);
			this->BtnNetejar->Name = L"BtnNetejar";
			this->BtnNetejar->Size = System::Drawing::Size(81, 34);
			this->BtnNetejar->TabIndex = 15;
			this->BtnNetejar->Text = L"Netejar";
			this->BtnNetejar->UseVisualStyleBackColor = true;
			this->BtnNetejar->Click += gcnew System::EventHandler(this, &Form1::BtnNetejar_Click);
			// 
			// Form1
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(8, 16);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(509, 425);
			this->Controls->Add(this->BtnNetejar);
			this->Controls->Add(this->btnEliminar);
			this->Controls->Add(this->btnActualitzar);
			this->Controls->Add(this->btnGuardar);
			this->Controls->Add(this->groupBox1);
			this->Name = L"Form1";
			this->RightToLeftLayout = true;
			this->Text = L"Productes";
			this->groupBox1->ResumeLayout(false);
			this->groupBox1->PerformLayout();
			this->ResumeLayout(false);

		}
#pragma endregion
	private: System::Void groupBox1_Enter(System::Object^ sender, System::EventArgs^ e) {
	}
	private: System::Void btnBuscar_Click(System::Object^ sender, System::EventArgs^ e) 
	{
		string codigo = this->toStandardString(txtCodi->Text);
		sql::ResultSet* result = nullptr;
		Connexio Obj;

		//Obrim connexió
		sql::Connection* conexionBD = Obj.conexion();

		try
		{
			sql::PreparedStatement* comando = conexionBD->prepareStatement(
				"SELECT * FROM productes WHERE id LIKE ? LIMIT 1"
			);

			// Concatenació segura en C++
			std::string param = "%" + codigo + "%";
			comando->setString(1, param);

			// Executar la consulta
			result = comando->executeQuery();
			while (result->next()) 
			{
				txtCodi->Text = StdStringToSystemString(result->getString("id"));
				txtNom->Text = StdStringToSystemString(result->getString("nom"));
				txtDescripcio->Text = StdStringToSystemString(result->getString("descripcio"));
				txtPreu->Text = StdStringToSystemString(result->getString("preu"));
				txtExistencies->Text = StdStringToSystemString(result->getString("existencies"));
			}
		}
		catch (sql::SQLException* ex)
		{
			MessageBox::Show("Error al buscar: " + ex->getErrorCode());
		}
		finally
		{
			conexionBD->close();
		}
	}

	private: static string toStandardString(System::String^ string)
	{
		using System::Runtime::InteropServices::Marshal;
		System::IntPtr pointer = Marshal::StringToHGlobalAnsi(string);
		char* charPointer = reinterpret_cast<char*>(pointer.ToPointer());
		std::string returnString(charPointer, string->Length);
		Marshal::FreeHGlobal(pointer);
		return returnString;
	}

	private: void Limpiar()
	{
		txtCodi->Text = "";
		txtDescripcio->Text = "";
		txtExistencies->Text = "";
		txtPreu->Text = "";
		txtNom->Text = "";
	}

	private: static System::String^ StdStringToSystemString(const std::string& stdStr) 
	{
		return gcnew System::String(stdStr.c_str());
	}

	private: System::Void btnGuardar_Click(System::Object^ sender, System::EventArgs^ e) 
	{
		string codigo = this->toStandardString(txtCodi->Text);
		string nombre = this->toStandardString(txtNom->Text);
		string descripcio = this->toStandardString(txtDescripcio->Text);

		double preu = 0;
		int existencies = 0;
		try
		{
			preu = double::Parse(txtPreu->Text);
			existencies = int::Parse(txtExistencies->Text);
		}
		catch (FormatException^ ex)
		{
			MessageBox::Show("Error: " + ex->Message);
			Limpiar();
			return;
		}

		sql::ResultSet* result = nullptr;
		Connexio Obj;

		//Obrim connexió
		sql::Connection* conexionBD = Obj.conexion();

		try
		{
			sql::PreparedStatement* comando = conexionBD->prepareStatement("INSERT INTO productes ( nom, descripcio, preu, existencies) VALUES (?,?,?,?)");

			// Concatenació segura en C++

			comando->setString(1, nombre);
			comando->setString(2, descripcio);
			comando->setDouble(3, preu);
			comando->setInt(4, existencies);

			// Executar la consulta
			result = comando->executeQuery();
			MessageBox::Show("Registro guardado");
			Limpiar();
		}
		catch (sql::SQLException* ex)
		{
			MessageBox::Show("Error al guardar: " + ex->getErrorCode());
		}
		finally
		{
			conexionBD->close();
		}
	}
	private: System::Void btnActualitzar_Click(System::Object^ sender, System::EventArgs^ e) 
	{
		string codigo = this->toStandardString(txtCodi->Text);
		string nombre = this->toStandardString(txtNom->Text);
		string descripcio = this->toStandardString(txtDescripcio->Text);

		double preu = 0;
		int existencies = 0;
		try
		{
			preu = double::Parse(txtPreu->Text);
			existencies = int::Parse(txtExistencies->Text);
		}
		catch (FormatException^ ex)
		{
			MessageBox::Show("Error: " + ex->Message);
			Limpiar();
			return;
		}

		sql::ResultSet* result = nullptr;
		Connexio Obj;

		//Obrim connexió
		sql::Connection* conexionBD = Obj.conexion();
		if (nombre != "" && descripcio != "" && preu > 0 && existencies > 0)
		{

			try
			{
				sql::PreparedStatement* comando = conexionBD->prepareStatement("UPDATE productes SET  nom = ?, descripcio = ?, preu = ?, existencies = ? WHERE id = ?");

				// Concatenació segura en C++

				comando->setString(1, nombre);
				comando->setString(2, descripcio);
				comando->setDouble(3, preu);
				comando->setInt(4, existencies);
				comando->setString(5, codigo);

				// Executar la consulta
				result = comando->executeQuery();
				MessageBox::Show("Registro actualizado");
				Limpiar();
			}
			catch (sql::SQLException* ex)
			{
				MessageBox::Show("Error al actualitzar: " + ex->getErrorCode());
			}
			finally
			{
				conexionBD->close();
			}
		}
		else
		{
			MessageBox::Show("Falten dades o no son correctes");
		}
	}

	private: System::Void btnEliminar_Click(System::Object^ sender, System::EventArgs^ e) 
	{
		string codigo = this->toStandardString(txtCodi->Text);

		sql::ResultSet* result = nullptr;
		Connexio Obj;

		//Obrim connexió
		sql::Connection* conexionBD = Obj.conexion();

		try
		{
			sql::PreparedStatement* comando = conexionBD->prepareStatement("DELETE FROM productes WHERE id = ?");

			// Concatenació segura en C++

			comando->setString(1, codigo);

			// Executar la consulta
			result = comando->executeQuery();
			MessageBox::Show("Registro eliminado");
			Limpiar();
		}
		catch (sql::SQLException* ex)
		{
			MessageBox::Show("Error al borrar: " + ex->getErrorCode());
		}
		finally
		{
			conexionBD->close();
		}
	}
	private: System::Void BtnNetejar_Click(System::Object^ sender, System::EventArgs^ e) 
	{
		Limpiar();
	}
};
}
