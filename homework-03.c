#include "mydll.h"
int max(int x,int y)
{
	if (x > y) return x;
	else return y;
}
void calc(int h,int v)
{
	freopen("input.txt","r",stdin);
	int a[100][100];
	int b[100][100];
	int m,n;
	int i,j,k,temp = 0;
	scanf("%d,",&m);
	scanf("%d,",&n);
	for (i = 1;i <= m;i++)
	for (j = 1;j <= n;j++)
	{
		scanf("%d,",&a[i][j]);
		a[i + m][j] = a[i][j];
		a[i][j + n] = a[i][j];
		a[i + m][j + n] = a[i][j];
	}
	fclose(stdin);
	ans = a[1][1];
	for (i = 1;i <= m;i++)
	for (j = 1;j <= n;j++) ans = max(ans,a[i][j]);
	memset(b,0,sizeof(b));
	int top;
	if (h == 0 && v == 1)
	{
		for (j = 1;j <= n;j++)
		{
			temp = 0;
			for (i = 1;i <= m * 2;i++)
			{
				temp = temp + a[i][j];
				b[i][j] = temp;
			}
		}
		for (i = 1;i <= m;i++)
		for (j = i;j <= m * 2;j++)
		{
			if ((j - i) < m)
			{
				temp = 0;top = 1;
				for (k = 1;k <= n;k++)
				{
					temp = temp + b[j][k] - b[i - 1][k];
					if (temp > ans)
					{
						ans = temp;
						begin_x = i;end_x = j;
						begin_y = top;end_y = k;
					}
					else if (temp < 0)
					{
						temp = 0;
						top = k + 1;
					}
				}
			}
		}
	}
	else if (h == 1 && v == 0)
	{
		for (i = 1;i <= m;i++)
		{
			temp = 0;
			for (j = 1;j <= n * 2;j++)
			{
				temp = temp + a[i][j];
				b[i][j] = temp;
			}
		}
		for (i = 1;i <= n;i++)
		for (j = i;j <= n * 2;j++)
		{
			if ((j - i) < n)
			{
				temp = 0;top = 1;
				for (k = 1;k <= m;k++)
				{
					temp = temp + b[k][j] - b[k][i - 1];
					if (temp > ans)
					{
						ans = temp;
						begin_y = i;end_y = j;
						begin_x = top;end_x = k;
					}
					else if (temp < 0)
					{
						temp = 0;
						top = k + 1;
					}
				}
			}
		}
	}
	else if (h == 0 && v == 0)
	{
		for (j = 1;j <= n;j++)
		{
			temp = 0;
			for (i = 1;i <= m;i++)
			{
				temp = temp + a[i][j];
				b[i][j] = temp;
			}
		}
		for (i = 1;i <= m;i++)
		for (j = i;j <= m;j++)
		{
			if ((j - i) < m)
			{
				temp = 0;top = 1;
				for (k = 1;k <= n;k++)
				{
					temp = temp + b[j][k] - b[i - 1][k];
					if (temp > ans)
					{
						ans = temp;
						begin_x = i;end_x = j;
						begin_y = top;end_y = k;
					}
					else if (temp < 0)
					{
						temp = 0;
						top = k + 1;
					}
				}
			}
		}
	}
	else
	{
		int length;
		for (j = 1;j <= n * 2;j++)
		{
			temp = 0;
			for (i = 1;i <= m * 2;i++)
			{
				temp = temp + a[i][j];
				b[i][j] = temp;
			}
		}
		for (i = 1;i <= m;i++)
		for (j = i;j <= m * 2;j++)
		{
			if ((j - i) < m)
			{
				temp = 0;length = 0;top = 1;
				for (k = 1;k <= n * 2;k++)
				{
					if (length < n)
					{
						temp = temp + b[j][k] - b[i - 1][k];
						length++;
					}
					else
					{
						temp = temp + b[j][k] - b[i - 1][k];
						temp = temp - b[j][k - 1] + b[i - 1][k - 1];
						top++;
					}
					if (temp > ans)
					{
						ans = temp;
						begin_x = i;end_x = j;
						begin_y = top;end_y = k;
					}
					else if (temp < 0)
					{
						temp = 0;
						length = 0;
						top = k + 1;
					}
				}
			}
		}
	}
}
int main()
{
	calc(1,1);
	printf("%d\n",ans);
	printf("%d %d\n%d %d\n",begin_x,begin_y,end_x,end_y); 
	return 0;
}
