<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Report3.aspx.cs" Inherits="CustomReports.Report3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="ECharts/echarts.js"></script>
    <script src="JS/jquery-3.2.1.min.js"></script>
</head>
<body>
  
    <div>
        <div id="main" style="width: 600px;height:400px"></div>
        <script type="text/javascript">
            var myChart = echarts.init(document.getElementById('main'));
            
            option = {
                title: {
                    text: '漏斗图',
                    subtext: '纯属虚构'
                },
                tooltip: {
                    trigger: 'item',
                    formatter: "{a} <br/>{b} : {c}%"
                },
                toolbox: {
                    show: true,
                    feature: {
                        mark: { show: true },
                        dataView: { show: true, readOnly: false },
                        restore: { show: true },
                        saveAsImage: { show: true }
                    }
                },
                legend: {
                    data: ['展现', '点击', '访问', '咨询', '订单']
                },
                calculable: true,
                series: [
                    {
                        name: '漏斗图',
                        type: 'funnel',
                        width: '40%',
                        data: [
                            { value: 60, name: '访问' },
                            { value: 40, name: '咨询' },
                            { value: 20, name: '订单' },
                            { value: 80, name: '点击' },
                            { value: 100, name: '展现' }
                        ]
                    }
                ]
            };
            // 使用刚指定的配置项和数据显示图表。
            myChart.setOption(option);
        </script>

    </div>
   
</body>
</html>
