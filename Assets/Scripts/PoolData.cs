public class PoolData
{
	public ObjectPoolManager objectPoolManager;
	public string poolName;

	public PoolData(string poolName, ObjectPoolManager objectPoolManager)
	{
		this.poolName = poolName;
		this.objectPoolManager = objectPoolManager;
	}
}
