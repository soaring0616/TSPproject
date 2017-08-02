using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;

namespace final
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private int[][] Graph;
		private double timeBound=0;
		private int[][] ReducedMatrix;
		private ArrayList FinalMatrix;		
		private System.Windows.Forms.Button Load;
		private System.Data.OleDb.OleDbConnection con;
		private System.Data.OleDb.OleDbDataAdapter ProblemAdapter;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		private System.Timers.Timer Time;
		private System.Data.OleDb.OleDbDataAdapter MatrixAdapter;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand2;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand2;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand2;
		private System.Timers.Timer calculate;
		private System.Data.OleDb.OleDbDataAdapter Solution;
		private System.Data.OleDb.OleDbCommand command;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand3;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand3;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand3;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand3;		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Load = new System.Windows.Forms.Button();
			this.con = new System.Data.OleDb.OleDbConnection();
			this.MatrixAdapter = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand2 = new System.Data.OleDb.OleDbCommand();
			this.ProblemAdapter = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
			this.Time = new System.Timers.Timer();
			this.calculate = new System.Timers.Timer();
			this.Solution = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand3 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand3 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand3 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand3 = new System.Data.OleDb.OleDbCommand();
			this.command = new System.Data.OleDb.OleDbCommand();
			((System.ComponentModel.ISupportInitialize)(this.Time)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.calculate)).BeginInit();
			this.SuspendLayout();
			// 
			// Load
			// 
			this.Load.Location = new System.Drawing.Point(80, 24);
			this.Load.Name = "Load";
			this.Load.TabIndex = 0;
			this.Load.Text = "Click to go...";
			this.Load.Click += new System.EventHandler(this.Load_Click);
			// 
			// con
			// 
			this.con.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Password="""";User ID=Admin;Data Source=C:\tsp.mdb;Mode=Share Deny None;Extended Properties="""";Jet OLEDB:System database="""";Jet OLEDB:Registry Path="""";Jet OLEDB:Database Password="""";Jet OLEDB:Engine Type=5;Jet OLEDB:Database Locking Mode=1;Jet OLEDB:Global Partial Bulk Ops=2;Jet OLEDB:Global Bulk Transactions=1;Jet OLEDB:New Database Password="""";Jet OLEDB:Create System Database=False;Jet OLEDB:Encrypt Database=False;Jet OLEDB:Don't Copy Locale on Compact=False;Jet OLEDB:Compact Without Replica Repair=False;Jet OLEDB:SFP=False";
			// 
			// MatrixAdapter
			// 
			this.MatrixAdapter.DeleteCommand = this.oleDbDeleteCommand2;
			this.MatrixAdapter.InsertCommand = this.oleDbInsertCommand2;
			this.MatrixAdapter.SelectCommand = this.oleDbSelectCommand1;
			this.MatrixAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									new System.Data.Common.DataTableMapping("Table", "tMatrices", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("row", "row"),
																																																				 new System.Data.Common.DataColumnMapping("Cost", "Cost"),
																																																				 new System.Data.Common.DataColumnMapping("problem", "problem")})});
			this.MatrixAdapter.UpdateCommand = this.oleDbUpdateCommand2;
			this.MatrixAdapter.RowUpdated += new System.Data.OleDb.OleDbRowUpdatedEventHandler(this.MatrixAdapter_RowUpdated);
			// 
			// oleDbDeleteCommand2
			// 
			this.oleDbDeleteCommand2.CommandText = "DELETE FROM tMatrices WHERE ([key] = ?) AND (contents = ? OR ? IS NULL AND conten" +
				"ts IS NULL)";
			this.oleDbDeleteCommand2.Connection = this.con;
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_key", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "key", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_contents", System.Data.OleDb.OleDbType.VarWChar, 250, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Cost", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_contents1", System.Data.OleDb.OleDbType.VarWChar, 250, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Cost", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand2
			// 
			this.oleDbInsertCommand2.CommandText = "INSERT INTO tMatrices(row, contents, problem, [key]) VALUES (?, ?, ?, ?)";
			this.oleDbInsertCommand2.Connection = this.con;
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("row", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "row", System.Data.DataRowVersion.Current, null));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("contents", System.Data.OleDb.OleDbType.VarWChar, 250, "Cost"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("problem", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "problem", System.Data.DataRowVersion.Current, null));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("key", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "key", System.Data.DataRowVersion.Current, null));
			// 
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.CommandText = "SELECT row, contents AS Cost, problem, [key] FROM tMatrices";
			this.oleDbSelectCommand1.Connection = this.con;
			// 
			// oleDbUpdateCommand2
			// 
			this.oleDbUpdateCommand2.CommandText = "UPDATE tMatrices SET row = ?, contents = ?, problem = ?, [key] = ? WHERE ([key] =" +
				" ?) AND (contents = ? OR ? IS NULL AND contents IS NULL)";
			this.oleDbUpdateCommand2.Connection = this.con;
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("row", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "row", System.Data.DataRowVersion.Current, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("contents", System.Data.OleDb.OleDbType.VarWChar, 250, "Cost"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("problem", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "problem", System.Data.DataRowVersion.Current, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("key", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "key", System.Data.DataRowVersion.Current, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_key", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "key", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_contents", System.Data.OleDb.OleDbType.VarWChar, 250, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Cost", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_contents1", System.Data.OleDb.OleDbType.VarWChar, 250, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Cost", System.Data.DataRowVersion.Original, null));
			// 
			// ProblemAdapter
			// 
			this.ProblemAdapter.DeleteCommand = this.oleDbDeleteCommand1;
			this.ProblemAdapter.InsertCommand = this.oleDbInsertCommand1;
			this.ProblemAdapter.SelectCommand = this.oleDbSelectCommand2;
			this.ProblemAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									 new System.Data.Common.DataTableMapping("Table", "tProblems", new System.Data.Common.DataColumnMapping[] {
																																																				  new System.Data.Common.DataColumnMapping("timeBound", "timeBound"),
																																																				  new System.Data.Common.DataColumnMapping("cities", "cities"),
																																																				  new System.Data.Common.DataColumnMapping("problemID", "problemID")})});
			this.ProblemAdapter.UpdateCommand = this.oleDbUpdateCommand1;
			// 
			// oleDbDeleteCommand1
			// 
			this.oleDbDeleteCommand1.CommandText = "DELETE FROM tProblems WHERE ([key] = ?) AND (timeBound = ? OR ? IS NULL AND timeB" +
				"ound IS NULL)";
			this.oleDbDeleteCommand1.Connection = this.con;
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_key", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "key", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_timeBound", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(15)), ((System.Byte)(0)), "timeBound", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_timeBound1", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(15)), ((System.Byte)(0)), "timeBound", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand1
			// 
			this.oleDbInsertCommand1.CommandText = "INSERT INTO tProblems(timeBound, cities, problemID, [key]) VALUES (?, ?, ?, ?)";
			this.oleDbInsertCommand1.Connection = this.con;
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("timeBound", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(15)), ((System.Byte)(0)), "timeBound", System.Data.DataRowVersion.Current, null));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("cities", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "cities", System.Data.DataRowVersion.Current, null));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("problemID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "problemID", System.Data.DataRowVersion.Current, null));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("key", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "key", System.Data.DataRowVersion.Current, null));
			// 
			// oleDbSelectCommand2
			// 
			this.oleDbSelectCommand2.CommandText = "SELECT timeBound, cities, problemID, [key] FROM tProblems";
			this.oleDbSelectCommand2.Connection = this.con;
			// 
			// oleDbUpdateCommand1
			// 
			this.oleDbUpdateCommand1.CommandText = "UPDATE tProblems SET timeBound = ?, cities = ?, problemID = ?, [key] = ? WHERE ([" +
				"key] = ?) AND (timeBound = ? OR ? IS NULL AND timeBound IS NULL)";
			this.oleDbUpdateCommand1.Connection = this.con;
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("timeBound", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(15)), ((System.Byte)(0)), "timeBound", System.Data.DataRowVersion.Current, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("cities", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "cities", System.Data.DataRowVersion.Current, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("problemID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "problemID", System.Data.DataRowVersion.Current, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("key", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "key", System.Data.DataRowVersion.Current, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_key", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "key", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_timeBound", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(15)), ((System.Byte)(0)), "timeBound", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_timeBound1", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(15)), ((System.Byte)(0)), "timeBound", System.Data.DataRowVersion.Original, null));
			// 
			// Time
			// 
			this.Time.Enabled = true;
			this.Time.SynchronizingObject = this;
			// 
			// calculate
			// 
			this.calculate.Enabled = true;
			this.calculate.SynchronizingObject = this;
			this.calculate.Elapsed += new System.Timers.ElapsedEventHandler(this.calculate_Elapsed);
			// 
			// Solution
			// 
			this.Solution.DeleteCommand = this.oleDbDeleteCommand3;
			this.Solution.InsertCommand = this.oleDbInsertCommand3;
			this.Solution.SelectCommand = this.oleDbSelectCommand3;
			this.Solution.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																							   new System.Data.Common.DataTableMapping("Table", "tSolutions", new System.Data.Common.DataColumnMapping[] {
																																																			 new System.Data.Common.DataColumnMapping("key", "key"),
																																																			 new System.Data.Common.DataColumnMapping("problem", "problem"),
																																																			 new System.Data.Common.DataColumnMapping("cost", "cost"),
																																																			 new System.Data.Common.DataColumnMapping("visitOrder", "visitOrder"),
																																																			 new System.Data.Common.DataColumnMapping("exactSolution", "exactSolution"),
																																																			 new System.Data.Common.DataColumnMapping("timeSpent", "timeSpent")})});
			this.Solution.UpdateCommand = this.oleDbUpdateCommand3;
			// 
			// oleDbDeleteCommand3
			// 
			this.oleDbDeleteCommand3.CommandText = "DELETE FROM tSolutions WHERE ([key] = ?) AND (exactSolution = ?) AND (timeSpent =" +
				" ? OR ? IS NULL AND timeSpent IS NULL) AND (visitOrder = ? OR ? IS NULL AND visi" +
				"tOrder IS NULL)";
			this.oleDbDeleteCommand3.Connection = this.con;
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_key", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "key", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_exactSolution", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "exactSolution", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_timeSpent", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(15)), ((System.Byte)(0)), "timeSpent", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_timeSpent1", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(15)), ((System.Byte)(0)), "timeSpent", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_visitOrder", System.Data.OleDb.OleDbType.VarWChar, 250, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "visitOrder", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_visitOrder1", System.Data.OleDb.OleDbType.VarWChar, 250, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "visitOrder", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand3
			// 
			this.oleDbInsertCommand3.CommandText = "INSERT INTO tSolutions(cost, exactSolution, problem, timeSpent, visitOrder) VALUE" +
				"S (?, ?, ?, ?, ?)";
			this.oleDbInsertCommand3.Connection = this.con;
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("cost", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "cost", System.Data.DataRowVersion.Current, null));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("exactSolution", System.Data.OleDb.OleDbType.Boolean, 2, "exactSolution"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("problem", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "problem", System.Data.DataRowVersion.Current, null));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("timeSpent", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(15)), ((System.Byte)(0)), "timeSpent", System.Data.DataRowVersion.Current, null));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("visitOrder", System.Data.OleDb.OleDbType.VarWChar, 250, "visitOrder"));
			// 
			// oleDbSelectCommand3
			// 
			this.oleDbSelectCommand3.CommandText = "SELECT cost, exactSolution, [key], problem, timeSpent, visitOrder FROM tSolutions" +
				"";
			this.oleDbSelectCommand3.Connection = this.con;
			// 
			// oleDbUpdateCommand3
			// 
			this.oleDbUpdateCommand3.CommandText = "UPDATE tSolutions SET cost = ?, exactSolution = ?, problem = ?, timeSpent = ?, vi" +
				"sitOrder = ? WHERE ([key] = ?) AND (exactSolution = ?) AND (timeSpent = ? OR ? I" +
				"S NULL AND timeSpent IS NULL) AND (visitOrder = ? OR ? IS NULL AND visitOrder IS" +
				" NULL)";
			this.oleDbUpdateCommand3.Connection = this.con;
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("cost", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "cost", System.Data.DataRowVersion.Current, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("exactSolution", System.Data.OleDb.OleDbType.Boolean, 2, "exactSolution"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("problem", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "problem", System.Data.DataRowVersion.Current, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("timeSpent", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(15)), ((System.Byte)(0)), "timeSpent", System.Data.DataRowVersion.Current, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("visitOrder", System.Data.OleDb.OleDbType.VarWChar, 250, "visitOrder"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_key", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "key", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_exactSolution", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "exactSolution", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_timeSpent", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(15)), ((System.Byte)(0)), "timeSpent", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_timeSpent1", System.Data.OleDb.OleDbType.Double, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(15)), ((System.Byte)(0)), "timeSpent", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_visitOrder", System.Data.OleDb.OleDbType.VarWChar, 250, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "visitOrder", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_visitOrder1", System.Data.OleDb.OleDbType.VarWChar, 250, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "visitOrder", System.Data.DataRowVersion.Original, null));
			// 
			// command
			// 
			this.command.Connection = this.con;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.Load});
			this.Name = "Form1";
			this.Text = "Form1";			
			((System.ComponentModel.ISupportInitialize)(this.Time)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.calculate)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void Load_Click(object sender, System.EventArgs e)
		{	
			command.Connection.Open();									
			DataSet ds=new DataSet();
			this.ProblemAdapter.Fill(ds);
			/*
			* Now we would Read the values of the cost from the 
			* database.
			* */			
			foreach (DataRow row in ds.Tables[0].Rows)
			{
				int cities;
				double timeBound;
				cities=Convert.ToInt16(row[1]);
				timeBound=Convert.ToDouble(row[0]);				
                Time.Enabled=true;
				Time.Interval=timeBound*1000;
				int prId=Convert.ToInt16(row[2]);
				/*
				 * LoadData loads the data.
				 * */
				LoadData(prId,cities);				
				// Timers starts here.
				Time.Start();
                calculate.Start();
				calculate.Interval=100;
				int cost=TSP(cities,timeBound);
				calculate.Stop();
				double x=this.timeBound;
				String str=this.getString();				
				writeToDB(prId,cost,str,x);
				Time.Stop();
			}

			//MessageBox.Show("reader.GetString(0)= "	+ reader.GetString(0)+" reader.GetString(1)="+reader.GetString(1));			

		}
		private int TSP(int cities,double timeBound)
		{		
		int totalCost=0;
			this.FinalMatrix=new ArrayList(20);
			/*
				 * The ReducedCostMatrix calculates the reduced
				 * cost matrix
				 * */
			totalCost=this.ReducedCostMatrix(cities);
			/*
			 	* Now we would work on the reduced cost
				 * Matrix to check which nodes to be inluded
				 * yet or not.
				 * */				
int l,m,count=0;
			for (int i=0;i<cities;i++)
				for (int j=0;j<cities;j++)
				{
					int[][] tempReduceRow=new int[cities][];
					for (l=0;l<cities;l++)
						tempReduceRow[l]=new int[cities];
					for (l=0;l<cities;l++)
						for (m=0;m<cities;m++)
							tempReduceRow[l][m]=this.ReducedMatrix[l][m];
					
					int[][] tempReduceCol=new int[cities][];
					for (l=0;l<cities;l++)
						tempReduceCol[l]=new int[cities];
					for (l=0;l<cities;l++)
						for (m=0;m<cities;m++)
							tempReduceCol[l][m]=this.ReducedMatrix[l][m];
/*
 * We only include those edges with value 0.
 * Now, we will have only those with minimum left
 * child and maximum right child.
 * */
					if (this.ReducedMatrix[i][j]==0)
					{
						OmitLeft(i,j,tempReduceRow);
						
						int LBound=totalCost+this.ReducedCostMatrix(cities,tempReduceRow);
						OmitRight(i,j,tempReduceCol);	
						int RBound=totalCost+this.ReducedCostMatrix(cities,tempReduceCol);	
						this.FinalMatrix.Add(new int[]{LBound,RBound,65+(count++)});
					}                                       
				}
		this.sort();		
		return totalCost;
		}
		
		private void writeToDB(int problemId,double cost,string moves,double time)
		{				
			DataSet ds=new DataSet();
			this.Solution.Fill(ds);
			DataRow row=ds.Tables[0].NewRow();
			row["problem"]=problemId;
			row["cost"]=cost;
			row["visitOrder"]=moves;
			row["exactSolution"]=1;
			row["timeSpent"]=time;
			ds.Tables[0].Rows.Add(row);
            this.Solution.Update(ds,"tSolutions");			
		}

		private void sort()
		{			
			int[] values=new int[3];
			int[] a=new int[3];
			int count=0;
			values=(int[])this.FinalMatrix[0];
			int i=0;
			int prevIndex=0;
			for (i=0;i<this.FinalMatrix.Count;i++)
				for(int j=0;j<this.FinalMatrix.Count;j++)
				{		
				a=(int[])this.FinalMatrix[j];
					if (a[1]>values[1]||a[0]<values[0])
					{							
						this.FinalMatrix[prevIndex]=this.FinalMatrix[j];
						this.FinalMatrix[j]=values;
						values=a;	
						prevIndex=j;						
					}				
				}				
		}
		
		private String getString()
		{
			String str=new String('A',20);
			str="";
			foreach(int[] a in this.FinalMatrix)
				str+=(char)(a[2]);			
			return str;
		}

		private void OmitLeft(int row,int col,int[][] temp)
		{			
				for (int j=0;j<temp.Length;j++)					
						temp[row][j]=-1;
				for (int j=0;j<temp.Length;j++)					
					temp[j][col]=-1;
		}

		private void OmitRight(int row,int col,int[][] temp)
		{
			temp[row][col]=-1;
		}

		private void LoadData(int problemId,int cities)
		{
			//Graph is initialized here.
			Graph=new int[cities][];
			for (int i=0;i<cities;i++)
				Graph[i]=new int[cities];

			DataSet ds=new DataSet();			
			this.MatrixAdapter.Fill(ds);

			foreach (DataRow row in ds.Tables[0].Rows)
				if (problemId==Convert.ToInt16(row[2]))
				{
					int rowNo;
					String[] cost=new String[cities];
					rowNo=Convert.ToInt16(row[0])-1;
					String s=new String('c',3);
					s=row[1].ToString();
					cost=s.Split(new Char[]{' '});
					int col=0;
					foreach (string str in cost)
					{
						if (str==""||col==Graph[0].Length)
							continue;
						else
						{
							Graph[rowNo][col]=Convert.ToInt16(str);																				
							if (rowNo==col)
								Graph[rowNo][col]=-1;
							col++;
						}
					}
				}							
		}

		private int ReducedCostMatrix(int cities)
		{
		int minBound=0;
			this.ReducedMatrix=new int[cities][];
			for (int i=0;i<cities;i++)
				ReducedMatrix[i]=new int[cities];
			/*
			 * Here we make a new Reduced Matrix
			 * by copying the original matrix
			 * into the new one.
			 * */
				for (int i=0;i<cities;i++)
					for (int j=0;j<cities;j++)
						this.ReducedMatrix[i][j]=this.Graph[i][j];
			minBound=this.ReducedRows(cities);
			minBound+=this.ReducedCols(cities);
		return minBound;
		}
		
		private int ReducedCostMatrix(int cities,int[][] temp)
		{
			int minBound=0;
			minBound=this.ReducedRows(cities,temp);
			minBound+=this.ReducedCols(cities,temp);
			return minBound;
		}

		private int ReducedRows(int cities)
		{
			int min=65535;			
			bool flag=false;
			int minBound=0;
			for (int i=0;i<cities;i++)
			{
			min=65535;
				for (int j=0;j<cities;j++)
					if (this.ReducedMatrix[i][j]<min&&this.ReducedMatrix[i][j]!=-1)
					{
						min=this.ReducedMatrix[i][j];
						flag=true;
					}
				if (flag)
				{
					this.SubtractRow(i,min);
					minBound+=min;				
				}
			}
		return minBound;	
		}
		private int ReducedRows(int cities,int[][] temp)
		{
			int min=65535;			
			int minBound=0;
			for (int i=0;i<cities;i++)
			{
				min=65535;
				bool flag=true;
				for (int j=0;j<cities;j++)
					if (temp[i][j]<min&&temp[i][j]!=-1)
					{
						min=temp[i][j];
                        flag=false;
					}
				if (!flag)
				{
					this.SubtractRow(i,min,temp);
					minBound+=min;				
				}
			}
			return minBound;	
		}
		private int ReducedCols(int cities)
		{
			int min=65535;			
			int minBound=0;
			for (int j=0;j<cities;j++)
			{
				for (int i=0;i<cities;i++)
					if (this.ReducedMatrix[i][j]<min&&this.ReducedMatrix[i][j]!=-1)
						min=this.ReducedMatrix[i][j];
				this.SubtractCol(j,min);
				minBound+=min;			
			}
			return minBound;	
		}

		private int ReducedCols(int cities,int[][] temp)
		{
			int min=65535;			
			int minBound=0;
			for (int j=0;j<cities;j++)
			{
				for (int i=0;i<cities;i++)
					if (temp[i][j]<min&&temp[i][j]!=-1)
						min=temp[i][j];
				this.SubtractCol(j,min,temp);
				minBound+=min;			
			}
			return minBound;	
		}
		private void SubtractRow(int row,int sub)
		{
			for (int j=0;j<this.ReducedMatrix[0].Length;j++)
				if (this.ReducedMatrix[row][j]==-1)
					continue;
					else
					this.ReducedMatrix[row][j]-=sub;					
		}

		private void SubtractRow(int row,int sub,int[][] temp)
		{
			for (int j=0;j<temp[0].Length;j++)
				if (temp[row][j]==-1)
					continue;
				else
					temp[row][j]-=sub;					
		}
		private void SubtractCol(int col,int sub)
		{
			for (int j=0;j<this.ReducedMatrix[0].Length;j++)
				if (this.ReducedMatrix[j][col]==-1)
					continue;				
				else
				this.ReducedMatrix[j][col]-=sub;
					
		}
		private void SubtractCol(int col,int sub,int[][] temp)
		{
			for (int j=0;j<temp.Length;j++)
				if (temp[j][col]==-1)
					continue;				
				else
					temp[j][col]-=sub;
					
		}
		private void Form1_Load(object sender, System.EventArgs e)
		{
			con.Open();
		}

		public static void OnTimedEvent(object source, System.Timers.ElapsedEventArgs e)
		{
			MessageBox.Show("Algorithm Failed to Process in the Given Bound");
		}

		private void MatrixAdapter_RowUpdated(object sender, System.Data.OleDb.OleDbRowUpdatedEventArgs e)
		{
		
		}

		private void calculate_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
		timeBound+=0.1;
		}

		private void Form1_Load_1(object sender, System.EventArgs e)
		{			
		}

		private void Form1_Load_2(object sender, System.EventArgs e)
		{
		
		}
	
	}
}
