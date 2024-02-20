namespace Steganographysaurus.Core
{
	public interface IStegoRepository
	{
		void Save(string filename, IStegoImage image);
		IStegoImage Load(string filename);
	}
}
