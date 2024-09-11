using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoTrack.Migrations;
using AutoTrackApi.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AutoTrackApi.Controllers
{
    [Route("api/[controller]")]
    public class RelatorioFinanceiroController : Controller
    {
    private readonly IGeralPersist _geralPersist;
    private readonly IServicoPersist _ServicoPersist;
    private readonly IMontagemPersist _MontagemPersist;

    private readonly IRelatorioFinanceiroPersist _IRelatorioFinanceiroPersist;


    public RelatorioFinanceiroController(IGeralPersist geralPersist, IServicoPersist servicoPersist, IMontagemPersist montagemPersist, IRelatorioFinanceiroPersist relatorioFinanceiroPersist)
    {
        _geralPersist = geralPersist;
        _ServicoPersist = servicoPersist;
        _MontagemPersist = montagemPersist;
        _IRelatorioFinanceiroPersist = relatorioFinanceiroPersist;
    }
     


[HttpGet("relatoriofinanceiro")]
public async Task<IActionResult> getservicoentredatas([FromQuery]DateTime datainIcio,[FromQuery] DateTime dataFim)
{
    var TotalOrcamento = await _IRelatorioFinanceiroPersist.GetValorTotalPeriodo(datainIcio, dataFim);

    return Ok(TotalOrcamento);
}
[HttpGet("Credito")]
public async Task<IActionResult> getsumperiodocredito([FromQuery]DateTime datainIcio,[FromQuery] DateTime dataFim)
{
    var TotalOrcamento = await _IRelatorioFinanceiroPersist.GetValorTotaCredito(datainIcio, dataFim);

    return Ok(TotalOrcamento);
}
[HttpGet("Débito")]
public async Task<IActionResult> getsumperiodoDebito([FromQuery]DateTime datainIcio,[FromQuery] DateTime dataFim)
{
    var TotalOrcamento = await _IRelatorioFinanceiroPersist.GetValorTotalDebito(datainIcio, dataFim);

    return Ok(TotalOrcamento);
}
[HttpGet("Dinheiro")]
public async Task<IActionResult> getsumperiodoDinheiro([FromQuery]DateTime datainIcio,[FromQuery] DateTime dataFim)
{
    var TotalOrcamento = await _IRelatorioFinanceiroPersist.GetValorTotalDinheiro(datainIcio, dataFim);

    return Ok(TotalOrcamento);
}
[HttpGet("Pix")]
public async Task<IActionResult> getsumperiodoPix([FromQuery]DateTime datainIcio,[FromQuery] DateTime dataFim)
{
    var TotalOrcamento = await _IRelatorioFinanceiroPersist.GetValorTotalPix(datainIcio, dataFim);

    return Ok(TotalOrcamento);
}
[HttpGet("relatoriofinanceironaopago")]
public async Task<IActionResult> getservicoentredatasNP([FromQuery]DateTime datainIcio,[FromQuery] DateTime dataFim)
{
    var TotalOrcamento = await _IRelatorioFinanceiroPersist.GetValorTotalPeriodoNP(datainIcio, dataFim);

    return Ok(TotalOrcamento);
}
[HttpGet("CreditoNPago")]
public async Task<IActionResult> getsumperiodocreditonaopago([FromQuery]DateTime datainIcio,[FromQuery] DateTime dataFim)
{
    var TotalOrcamento = await _IRelatorioFinanceiroPersist.GetValorTotaCreditoNP(datainIcio, dataFim);

    return Ok(TotalOrcamento);
}
[HttpGet("DébitoNPago")]
public async Task<IActionResult> getsumperiodoDebitonaopago([FromQuery]DateTime datainIcio,[FromQuery] DateTime dataFim)
{
    var TotalOrcamento = await _IRelatorioFinanceiroPersist.GetValorTotalDebitoNP(datainIcio, dataFim);

    return Ok(TotalOrcamento);
}
[HttpGet("DinheiroNPago")]
public async Task<IActionResult> getsumperiodoDinheironaopago([FromQuery]DateTime datainIcio,[FromQuery] DateTime dataFim)
{
    var TotalOrcamento = await _IRelatorioFinanceiroPersist.GetValorTotalDinheiroNP(datainIcio, dataFim);

    return Ok(TotalOrcamento);
}
[HttpGet("PixNpago")]
public async Task<IActionResult> getsumperiodoPixNaopago([FromQuery]DateTime datainIcio,[FromQuery] DateTime dataFim)
{
    var TotalOrcamento = await _IRelatorioFinanceiroPersist.GetValorTotalPixNP(datainIcio, dataFim);

    return Ok(TotalOrcamento);
}
[HttpGet("relatorioMonfinanceiro")]
public async Task<IActionResult> getMontservicoentredatas([FromQuery]DateTime datainIcio,[FromQuery] DateTime dataFim)
{
    var TotalOrcamento = await _IRelatorioFinanceiroPersist.GetMontValorTotalPeriodo(datainIcio, dataFim);

    return Ok(TotalOrcamento);
}
[HttpGet("CreditoMon")]
public async Task<IActionResult> getMonsumperiodocredito([FromQuery]DateTime datainIcio,[FromQuery] DateTime dataFim)
{
    var TotalOrcamento = await _IRelatorioFinanceiroPersist.GetMonValorTotaCredito(datainIcio, dataFim);

    return Ok(TotalOrcamento);
}
[HttpGet("DébitoMon")]
public async Task<IActionResult> getMonsumperiodoDebito([FromQuery]DateTime datainIcio,[FromQuery] DateTime dataFim)
{
    var TotalOrcamento = await _IRelatorioFinanceiroPersist.GetValorTotalDebito(datainIcio, dataFim);

    return Ok(TotalOrcamento);
}
[HttpGet("DinheiroMon")]
public async Task<IActionResult> getMonsumperiodoDinheiro([FromQuery]DateTime datainIcio,[FromQuery] DateTime dataFim)
{
    var TotalOrcamento = await _IRelatorioFinanceiroPersist.GetMonValorTotalDinheiro(datainIcio, dataFim);

    return Ok(TotalOrcamento);
}
[HttpGet("PixMon")]
public async Task<IActionResult> getMonsumperiodoPix([FromQuery]DateTime datainIcio,[FromQuery] DateTime dataFim)
{
    var TotalOrcamento = await _IRelatorioFinanceiroPersist.GetMonValorTotalPix(datainIcio, dataFim);

    return Ok(TotalOrcamento);
}
[HttpGet("relatorioMonfinanceironaopago")]
public async Task<IActionResult> getMonservicoentredatasNP([FromQuery]DateTime datainIcio,[FromQuery] DateTime dataFim)
{
    var TotalOrcamento = await _IRelatorioFinanceiroPersist.GetMonValorTotalPeriodoNP(datainIcio, dataFim);

    return Ok(TotalOrcamento);
}
[HttpGet("CreditoMonNPago")]
public async Task<IActionResult> getMonsumperiodocreditonaopago([FromQuery]DateTime datainIcio,[FromQuery] DateTime dataFim)
{
    var TotalOrcamento = await _IRelatorioFinanceiroPersist.GetMonValorTotaCreditoNP(datainIcio, dataFim);

    return Ok(TotalOrcamento);
}
[HttpGet("DébitoMonNPago")]
public async Task<IActionResult> getMonsumperiodoDebitonaopago([FromQuery]DateTime datainIcio,[FromQuery] DateTime dataFim)
{
    var TotalOrcamento = await _IRelatorioFinanceiroPersist.GetMonValorTotalDebitoNP(datainIcio, dataFim);

    return Ok(TotalOrcamento);
}
[HttpGet("DinheiroMonNPago")]
public async Task<IActionResult> getMonsumperiodoDinheironaopago([FromQuery]DateTime datainIcio,[FromQuery] DateTime dataFim)
{
    var TotalOrcamento = await _IRelatorioFinanceiroPersist.GetMonValorTotalDinheiroNP(datainIcio, dataFim);

    return Ok(TotalOrcamento);
}
[HttpGet("PixMonNpago")]
public async Task<IActionResult> getMonsumperiodoPixNaopago([FromQuery]DateTime datainIcio,[FromQuery] DateTime dataFim)
{
    var TotalOrcamento = await _IRelatorioFinanceiroPersist.GetMonValorTotalPixNP(datainIcio, dataFim);

    return Ok(TotalOrcamento);
}
    }
}