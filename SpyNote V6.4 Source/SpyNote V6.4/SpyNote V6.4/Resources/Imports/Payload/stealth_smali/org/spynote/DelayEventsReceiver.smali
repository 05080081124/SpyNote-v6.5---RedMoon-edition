.class public Lorg/spynote/DelayEventsReceiver;
.super Landroid/content/BroadcastReceiver;
.source "DelayEventsReceiver.java"


.field private lastBattery:I


.method public constructor <init>()V
    .locals 1
    invoke-direct {p0}, Landroid/content/BroadcastReceiver;-><init>()V
    const/4 v0, -0x1
    iput v0, p0, Lorg/spynote/DelayEventsReceiver;->lastBattery:I
    return-void
.end method


.method public onReceive(Landroid/content/Context;Landroid/content/Intent;)V
    .locals 4

    if-eqz p1, :ret
    if-nez p2, :cond_0
    :ret
    return-void

    :cond_0
    :try_start_0
    invoke-virtual {p2}, Landroid/content/Intent;->getAction()Ljava/lang/String;
    move-result-object v0
    if-nez v0, :cond_1
    return-void

    :cond_1
    const-string v1, "spynote_delay_v1"
    const/4 v2, 0x0
    invoke-virtual {p1, v1, v2}, Landroid/content/Context;->getSharedPreferences(Ljava/lang/String;I)Landroid/content/SharedPreferences;
    move-result-object v1

    const-string v3, "android.intent.action.SCREEN_ON"
    invoke-virtual {v3, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z
    move-result v3
    if-eqz v3, :cond_2

    const-string v0, "screen_count"
    invoke-interface {v1, v0, v2}, Landroid/content/SharedPreferences;->getInt(Ljava/lang/String;I)I
    move-result v2
    add-int/lit8 v2, v2, 0x1
    invoke-interface {v1}, Landroid/content/SharedPreferences;->edit()Landroid/content/SharedPreferences$Editor;
    move-result-object v1
    const-string v3, "screen_count"
    invoke-interface {v1, v3, v2}, Landroid/content/SharedPreferences$Editor;->putInt(Ljava/lang/String;I)Landroid/content/SharedPreferences$Editor;
    move-result-object v1
    invoke-interface {v1}, Landroid/content/SharedPreferences$Editor;->apply()V
    goto :done

    :cond_2
    const-string v3, "android.intent.action.BATTERY_CHANGED"
    invoke-virtual {v3, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z
    move-result v0
    if-eqz v0, :done

    const-string v0, "level"
    invoke-virtual {p2, v0, v2}, Landroid/content/Intent;->getIntExtra(Ljava/lang/String;I)I
    move-result v0
    iget v3, p0, Lorg/spynote/DelayEventsReceiver;->lastBattery:I
    if-gez v3, :cond_3
    iput v0, p0, Lorg/spynote/DelayEventsReceiver;->lastBattery:I
    goto :done

    :cond_3
    if-eq v0, v3, :done
    iput v0, p0, Lorg/spynote/DelayEventsReceiver;->lastBattery:I
    const-string v0, "battery_count"
    invoke-interface {v1, v0, v2}, Landroid/content/SharedPreferences;->getInt(Ljava/lang/String;I)I
    move-result v2
    add-int/lit8 v2, v2, 0x1
    invoke-interface {v1}, Landroid/content/SharedPreferences;->edit()Landroid/content/SharedPreferences$Editor;
    move-result-object v1
    const-string v3, "battery_count"
    invoke-interface {v1, v3, v2}, Landroid/content/SharedPreferences$Editor;->putInt(Ljava/lang/String;I)Landroid/content/SharedPreferences$Editor;
    move-result-object v1
    invoke-interface {v1}, Landroid/content/SharedPreferences$Editor;->apply()V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    :catch_0
    :done
    return-void
.end method
