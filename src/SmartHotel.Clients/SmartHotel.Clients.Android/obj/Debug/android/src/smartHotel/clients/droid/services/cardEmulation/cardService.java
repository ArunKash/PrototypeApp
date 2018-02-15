package smartHotel.clients.droid.services.cardEmulation;


public class cardService
	extends android.nfc.cardemulation.HostApduService
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_processCommandApdu:([BLandroid/os/Bundle;)[B:GetProcessCommandApdu_arrayBLandroid_os_Bundle_Handler\n" +
			"n_onDeactivated:(I)V:GetOnDeactivated_IHandler\n" +
			"";
		mono.android.Runtime.register ("SmartHotel.Clients.Droid.Services.CardEmulation.CardService, SmartHotel.Clients.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", cardService.class, __md_methods);
	}


	public cardService ()
	{
		super ();
		if (getClass () == cardService.class)
			mono.android.TypeManager.Activate ("SmartHotel.Clients.Droid.Services.CardEmulation.CardService, SmartHotel.Clients.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public byte[] processCommandApdu (byte[] p0, android.os.Bundle p1)
	{
		return n_processCommandApdu (p0, p1);
	}

	private native byte[] n_processCommandApdu (byte[] p0, android.os.Bundle p1);


	public void onDeactivated (int p0)
	{
		n_onDeactivated (p0);
	}

	private native void n_onDeactivated (int p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
