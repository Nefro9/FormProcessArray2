using System;

class DataProcess
{
	int [] data;
	public int [] dublicated;

	
	public DataProcess(int[] array)
	{
		this.data = array;
		this.process();
	}
	
	private void process()
	{
		dublicated	= new int[data.Length];
		
		int counter = 0;
		
		for (int i = 0; i < data.Length; i++)
		{
			if (data[i] < 0) {
				for (int j = i + 1; j < data.Length; j++) {
					
					if (data[i] == data[j]) {
						dublicated[counter] = data[i];
						counter++;
					}
				}
			}
		}
		
		// Resize array
		Array .Resize<int >(ref dublicated, counter);
	}
	
	public bool isItemsFound()
	{
		bool result = false;
		
		if (dublicated.Length > 0) {
			result = true;
		}
		
		return result;
	}
	
	
	public string getDublicatedList()
	{
		return getList(dublicated);
	}
	
	private string getList(int[] array)
	{
		string arrayList = "";
		
		if (array.Length > 0) {
			
			for(int i = 0; i < array.Length; i++) {
				arrayList += array[i];
				
				if(array.Length > i+1) {
					arrayList += ", ";
				}
			}
		} else {
			arrayList = "Array not initialized";
		}
		
		return arrayList;
	}
}